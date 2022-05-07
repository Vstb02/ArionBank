using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArionBank.Application.Models
{
    public class CreateCreditModel
    { 
        public Guid CardId { get; set; }
        [Required(ErrorMessage = "{0} обязательно должно быть заполнено")]
        [Display(Name = "Сумма")]
        public decimal Ammount { get; set; }
        public DateTime Term { get; set; }
        [Required(ErrorMessage = "{0} обязательно должно быть заполнено")]
        [Display(Name = "Место работы")]
        public string PlaceOfWork { get; set; }
        [Required(ErrorMessage = "{0} обязательно должно быть заполнено")]
        [Display(Name = "Средняя заработная плат")]
        public decimal AverageSalary { get; set; }
        public bool Insurance { get; set; }
        [Required(ErrorMessage = "{0} обязательно должно быть заполнено")]
        [Display(Name = "Цель")]
        public string Purpose { get; set; }
    }
}
