using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstBank.Core.Domain.DTOs
{
    public class CustomerFieldsDTO
    {
        public string AccountName { get; set; }
        public string AccountNumber { get; set; }
        public string Industry { get; set; }
        public List<string> Fields { get; set; }
    }
}
