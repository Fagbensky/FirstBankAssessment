using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstBank.Core.Domain.Entities
{
    public class Industry
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<RequiredField> RequiredFields { get; set; }
    }
}
