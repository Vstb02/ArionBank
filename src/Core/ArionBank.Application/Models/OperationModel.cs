using ArionBank.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArionBank.Application.Models
{
    public class OperationModel
    {
        public Guid CardId { get; set; }
        [Required(ErrorMessage = "{0} обязательно должно быть заполнено")]
        [Display(Name = "Номер")]
        public string Number { get; set; }
        [Required(ErrorMessage = "{0} обязательно должно быть заполнено")]
        [Display(Name = "Сумма")]
        public decimal Ammount { get; set; }
        public byte[]? Image { get; set; }
    }
}
