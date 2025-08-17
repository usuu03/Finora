using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using Finora.Application.Common.Interfaces;
using Finora.Domain.Entities;
using Finora.Infrastructure.Services.Auth.Models;
using Microsoft.IdentityModel.Tokens;

namespace Finora.Infrastructure.Services.Auth;

public sealed class TokenService : ITokenService
{
    private readonly JwtOptions _options;
    private readonly SigningCredentials _signingCredentials;

    public TokenService(JwtOptions options)
    {
        _options = options;
        var key = new SymmetricSecurityKey(Convert.FromBase64String(_options.SigningKey));
        _signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
    }

    public (string accessToken, DateTime expiresAtUtc, string refreshToken)
    IssueTokens(AppUser user, IEnumerable<Claim>? extraClaims = null)
    {
        var now = DateTime.UtcNow;
        var expires = now.AddMinutes(_options.AccessTokenMinutes);

        var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new(JwtRegisteredClaimNames.Email, user.Email ?? string.Empty),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new(ClaimTypes.Name, user.UserName ?? user.Email ?? string.Empty)
        };

        if (extraClaims != null)
        {
            claims.AddRange(extraClaims);
        }

        var token = new JwtSecurityToken(
            issuer: _options.Issuer,
            audience: _options.Audience,
            claims: claims,
            notBefore: now,
            expires: expires,
            signingCredentials: _signingCredentials
        );

        var accessToken = new JwtSecurityTokenHandler().WriteToken(token);
        var refreshToken = GenerateRefreshToken();

        return (accessToken, expires, refreshToken);
    }


    private static string GenerateRefreshToken()
    {
        // 256-bit random token, Base64Url encoded
        Span<byte> bytes = stackalloc byte[32];
        RandomNumberGenerator.Fill(bytes);
        return Base64UrlEncoder.Encode(bytes.ToArray());
    }

}
