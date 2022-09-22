using Microsoft.AspNetCore.Identity;
namespace Core.Entities.Identity
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Profession { get; set; } = string.Empty;
        public string PhotoUrl { get; set; } = string.Empty;
    }
}