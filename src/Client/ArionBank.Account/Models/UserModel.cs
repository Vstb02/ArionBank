using System.ComponentModel.DataAnnotations;

namespace ArionBank.Account.Models
{
    public class UserModel
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Patronymic { get; set; }
        public string? Login { get; set; }
        public string? Email { get; set; }
        public byte[]? Image { get; set; }
    }
}
