using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArionBank.Application.Models
{
    public class DepositModel
    {
        [MaxLength(200)]
        public int Number { get; set; }
        [MaxLength(5)]
        public decimal Procent { get; set; }
        [MaxLength(20)]
        public decimal Balance { get; set; }
    }
}
