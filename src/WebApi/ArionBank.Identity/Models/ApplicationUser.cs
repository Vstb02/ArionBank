using Microsoft.AspNetCore.Identity;

namespace ArionBank.Identity.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public DateTime LastLogin { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public byte[]? Avatar { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
    }
}
