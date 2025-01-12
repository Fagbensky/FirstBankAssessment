using FirstBank.Core.Application.Interfaces.Repositories;
using FirstBank.Core.Domain.Entities;
using FirstBank.Core.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstBank.Core.Infrastructure.Repositories
{
    public class CustomerRepository: ICustomerRepository
    {
        private readonly CustomerContext _context;
        public CustomerRepository(CustomerContext context) 
        {
            _context = context;
        }
        public async Task<Customer?> GetCustomerByAccountNumberAsync(string accountNumber)
        {
            return await _context.Customers
            .Include(c => c.Industry)
            .Include(c => c.Industry.RequiredFields)
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.AccountNumber == accountNumber);
        }
    }
}
