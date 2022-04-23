using System.ComponentModel.DataAnnotations;

namespace ArionBank.Account.Models
{
    public class UserModel
    {

        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Patronymic { get; set; }
        public string? Email { get; set; }
        public byte[]? Avatar { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
    }
}
