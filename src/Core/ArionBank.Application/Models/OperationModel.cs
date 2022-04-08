using ArionBank.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArionBank.Application.Models
{
    public class OperationModel
    {
        public Guid CardId { get; set; }
        public string Number { get; set; }
        public decimal Ammount { get; set; }
        public byte[]? Image { get; set; }
    }
}
