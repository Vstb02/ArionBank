using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArionBank.Application.Models
{
    public class OperationResult
    {
        public bool Successful { get; set; }
        public List<string> Errors = new List<string>();
    }
}
