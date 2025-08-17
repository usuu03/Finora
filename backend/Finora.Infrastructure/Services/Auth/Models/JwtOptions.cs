using System;

namespace Finora.Infrastructure.Services.Auth.Models;

public sealed class JwtOptions
{
    public const string SectionName = "Jwt";
    public string Issuer { get; init; } = default!;
    public string Audience { get; init; } = default!;
    public int AccessTokenMinutes { get; init; } = 60;
    public string SigningKey { get; init; } = default!;
}