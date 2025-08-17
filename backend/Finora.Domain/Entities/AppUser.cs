using Microsoft.AspNetCore.Identity;

namespace Finora.Domain.Entities;

public class AppUser : IdentityUser<Guid>
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string? AvatarUrl { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }

    public bool Equals(AppUser? other)
    {
        return other is not null &&
               Id == other.Id &&
               FirstName == other.FirstName &&
               LastName == other.LastName &&
               AvatarUrl == other.AvatarUrl;
    }

}
