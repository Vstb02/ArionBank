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
        public int Number { get; set; }
        [MaxLength(5)]
        public decimal Procent { get; set; }
        [MaxLength(20)]
        public decimal Balance { get; set; }
        public Guid CardId { get; set; }
        public DateTime DateTime { get; set; }
        public DateTime LastMoth { get; set; }
        public Guid UserId { get; set; }
    }
}
