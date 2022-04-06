using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArionBank.Domain.Entities
{
    public class Account
    {
        [Key]
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public List<Card> Cards { get; set; }
        public List<Credit> Credits { get; set; }
        public List<Deposit> Deposits { get; set; }
    }
}
