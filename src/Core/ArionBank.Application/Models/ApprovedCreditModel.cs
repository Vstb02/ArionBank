using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArionBank.Application.Models
{
    public class ApprovedCreditModel
    {
        public Guid CreditId { get; set; }
        public bool IsApproved { get; set; }
    }
}
