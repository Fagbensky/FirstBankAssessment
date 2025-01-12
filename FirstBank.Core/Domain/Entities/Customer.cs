using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstBank.Core.Domain.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public string AccountNumber { get; set; }
        public string Name { get; set; }
        public int IndustryId { get; set; }
        public Industry Industry { get; set; } 
    }
}
