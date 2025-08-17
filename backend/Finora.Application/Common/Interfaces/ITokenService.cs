using System;
using System.Security.Claims;
using Finora.Domain.Entities;

namespace Finora.Application.Common.Interfaces;

public interface ITokenService
{
    (string accessToken, DateTime expiresAtUtc, string refreshToken) IssueTokens(AppUser user, IEnumerable<Claim>? extraClaims = null);
}
