namespace Finora.Application.Controllers.User.Models;

public record UserDto
{
    public Guid Id { get; set; }
    public string Email { get; set; } = default!;
    public string? DisplayName { get; set; }

}
