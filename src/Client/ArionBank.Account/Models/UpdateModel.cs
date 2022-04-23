using System.ComponentModel.DataAnnotations;

namespace ArionBank.Account.Models
{
    public class UpdateModel
    {
        [Required(ErrorMessage = "{0} обязательно должно быть заполнено")]
        [StringLength(100, ErrorMessage = "Длина {0} должна быть не менее {2} и не более {1} символов.", MinimumLength = 2)]
        [Display(Name = "Имя")]
        public string Name { get; set; }
        [Required(ErrorMessage = "{0} обязательно должно быть заполнено")]
        [StringLength(100, ErrorMessage = "Длина {0} должна быть не менее {2} и не более {1} символов.", MinimumLength = 2)]
        [Display(Name = "Фамилия")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "{0} обязательно должно быть заполнено")]
        [StringLength(100, ErrorMessage = "Длина {0} должна быть не менее {2} и не более {1} символов.", MinimumLength = 2)]
        [Display(Name = "Отчество")]
        public string Patronymic { get; set; }
        public byte[]? Avatar { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
    }
}
