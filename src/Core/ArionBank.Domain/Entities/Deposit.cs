using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArionBank.Domain.Entities
{
    public class Deposit
    {
        [Key]
        public Guid Id { get; set; }
        [MaxLength(200)]
        public string Number { get; set; }
        [MaxLength(5)]
        public decimal Procent { get; set; }
        [MaxLength(20)]
        public string Balance { get; set; }
    }
}
