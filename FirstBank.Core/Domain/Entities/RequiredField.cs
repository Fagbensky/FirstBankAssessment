using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstBank.Core.Domain.Entities
{
    public class RequiredField
    {
        public int Id { get; set; }
        public int IndustryId { get; set; }
        public Industry Industry { get; set; }
        public string FieldName { get; set; }
    }
}
