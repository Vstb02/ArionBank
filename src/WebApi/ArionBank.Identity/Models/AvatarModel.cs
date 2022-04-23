using System.ComponentModel.DataAnnotations;

namespace ArionBank.Identity.Models
{
    public class AvatarModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public byte[] Avatar { get; set; }
    }
}
