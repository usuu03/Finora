namespace Finora.Application.Controllers.User.Models;

public record class LogoutResponse
{
    public bool Success { get; set; } = true;
    public string Message { get; set; } = "Logged out successfully";

}
