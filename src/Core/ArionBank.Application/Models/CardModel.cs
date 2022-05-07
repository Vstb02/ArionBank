using ArionBank.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArionBank.Application.Models
{
    public class CardModel
    {
        public Guid Id { get; set; }
        [MaxLength(200)]
        public string Number { get; set; }
        [MaxLength(200)]
        public string Name { get; set; }
        [MaxLength(200)]
        public string Surname { get; set; }
        [MaxLength(20)]
        public decimal Balance { get; set; }
        [MaxLength(10)]
        public int Bonus { get; set; }
        public Statuses Status { get; set; }
        public PaymentSystems PaymentSystem { get; set; }
        public TypesCard Type { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public DateTime Actived { get; set; }
    }
}
