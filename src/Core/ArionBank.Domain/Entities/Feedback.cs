using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArionBank.Domain.Entities
{
    public class Feedback
    {
        [Key]
        public Guid Id { get; set; }
        public string Number { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Problem { get; set; }
    }
}
