using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArionBank.Application.Models
{
    public class CreateDepositModel
    {
        public decimal Ammount { get; set; }
        public Guid CardId { get; set; }
        public DateTime Date { get; set; }
        public DateTime Created { get; set; }
    }
}
