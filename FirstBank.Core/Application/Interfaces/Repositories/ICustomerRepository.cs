using FirstBank.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstBank.Core.Application.Interfaces.Repositories
{
    public interface ICustomerRepository
    {
        Task<Customer?> GetCustomerByAccountNumberAsync(string accountNumber);
    }
}
