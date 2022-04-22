namespace ArionBank.Identity.Models
{
    public class UserModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string Role { get; set; }
        public string Login { get; set; }
        public byte[] Avatar { get; set; }
    }
}
