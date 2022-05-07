using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArionBank.Application.Models
{
    public class CreditModel
    {
        public Guid Id { get; set; }
        public decimal Ammount { get; set; }
        public Guid CardId { get; set; }
        public DateTime Term { get; set; }
        public string PlaceOfWork { get; set; }
        public decimal AverageSalary { get; set; }
        public bool Insurance { get; set; }
        public string Purpose { get; set; }
        public bool Approved { get; set; }
    }
}
