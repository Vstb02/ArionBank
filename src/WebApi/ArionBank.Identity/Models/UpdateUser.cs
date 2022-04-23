using System.ComponentModel.DataAnnotations;

namespace ArionBank.Identity.Models
{
    public class UpdateUser
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string Patronymic { get; set; }
        public byte[]? Avatar { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
    }
}
