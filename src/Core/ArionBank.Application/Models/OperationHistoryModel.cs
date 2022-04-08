using ArionBank.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArionBank.Application.Models
{
    public class OperationHistoryModel
    {
        public byte[]? Image { get; set; }
        public decimal Ammount { get; set; }
        public DateTime Created { get; set; }
        public TypesOperation Type { get; set; }
    }
}
