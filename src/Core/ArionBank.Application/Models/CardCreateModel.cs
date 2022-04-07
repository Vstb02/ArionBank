using ArionBank.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArionBank.Application.Models
{
    public class CardCreateModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public PaymentSystems PaymentSystem { get; set; }
        public TypesCard Type { get; set; }
    }
}
