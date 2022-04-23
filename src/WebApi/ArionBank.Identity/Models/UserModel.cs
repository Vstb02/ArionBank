namespace ArionBank.Identity.Models
{
    public class UserModel
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Patronymic { get; set; }
        public string? Role { get; set; }
        public string? Login { get; set; }
        public byte[]? Avatar { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
    }
}
