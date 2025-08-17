namespace Finora.Application.Controllers.User.Models;

public record LoginResponseDto
{
    public string AccessToken { get; set; } = default!;
    public DateTime AccessTokenExpiresAtUtc { get; set; }
    public string RefreshToken { get; set; } = default!;
    public UserDto User { get; set; } = default!;
}
