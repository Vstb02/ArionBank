using System.ComponentModel.DataAnnotations;

namespace ArionBank.Account.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "{0} обязательно должно быть заполнено")]
        [Display(Name = "Логин")]
        public string Login { get; set; }

        [Required(ErrorMessage = "{0} обязательно должно быть заполнено"]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
