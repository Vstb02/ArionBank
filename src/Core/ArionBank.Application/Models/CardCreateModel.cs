using ArionBank.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArionBank.Application.Models
{
    public class CardCreateModel
    {
        public Guid UserId { get; set; }
        [Required(ErrorMessage = "{0} обязательно должно быть заполнено")]
        [Display(Name = "Имя")]
        public string Name { get; set; }
        [Required(ErrorMessage = "{0} обязательно должно быть заполнено")]
        [Display(Name = "Фамилия")]
        public string Surname { get; set; }
        public PaymentSystems PaymentSystem { get; set; }
        public TypesCard Type { get; set; }
    }
}
