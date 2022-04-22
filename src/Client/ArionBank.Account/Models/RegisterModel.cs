using ArionBank.Account.Enums;
using System.ComponentModel.DataAnnotations;

namespace ArionBank.Account.Models
{
    public class RegisterModel
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

        [Required(ErrorMessage = "{0} обязательно должно быть заполнено")]
        [StringLength(100, ErrorMessage = "Длина {0} должна быть не менее {2} и не более {1} символов.", MinimumLength = 4)]
        [Display(Name = "Логин")]
        public string Login { get; set; }

        [Required(ErrorMessage = "{0} обязательно должно быть заполнено")]
        [StringLength(100, ErrorMessage = "Длина {0} должна быть не менее {2} и не более {1} символов.", MinimumLength = 5)]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Required(ErrorMessage = "{0} обязательно должно быть заполнено")]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль еще раз")]
        [Compare("Password", ErrorMessage = "Пароль и пароль подтверждения не совпадают.")]
        public string ConfirmPassword { get; set; }
    }
}
