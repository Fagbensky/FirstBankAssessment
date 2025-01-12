using FirstBank.Core.Application.Interfaces.Repositories;
using FirstBank.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstBank.Core.Infrastructure.Repositories
{
    public class DummyCustomerRepository : ICustomerRepository
    {
        private static readonly List<Customer> _customers = new List<Customer>()
    {
        new Customer
        {
            Id = 1,
            AccountNumber = "1234567890",
            Name = "Manufacturer A",
            Industry = new Industry
            {
                Id = 1,
                Name = "Manufacturing",
                RequiredFields = new List<RequiredField>
                {
                    new RequiredField { Id = 1, FieldName = "Invoice Number" },
                    new RequiredField { Id = 2, FieldName = "Quantity" },
                    new RequiredField { Id = 3, FieldName = "Delivery Address" }
                }
            }
        },
        new Customer
        {
            Id = 2,
            AccountNumber = "2345678901",
            Name = "School B",
            Industry = new Industry
            {
                Id = 2,
                Name = "Education",
                RequiredFields = new List<RequiredField>
                {
                    new RequiredField { Id = 4, FieldName = "Matric Number" },
                    new RequiredField { Id = 5, FieldName = "Level" },
                    new RequiredField { Id = 6, FieldName = "Course" }
                }
            }
        },
                new Customer
        {
            Id = 3,
            AccountNumber = "3456789012",
            Name = "Telecom C",
            Industry = new Industry
            {
                Id = 3,
                Name = "Telecom",
                RequiredFields = new List<RequiredField>
                {
                    new RequiredField { Id = 7, FieldName = "GSM Number" },
                    new RequiredField { Id = 8, FieldName = "Network" },
                    new RequiredField { Id = 9, FieldName = "Residential Address" }
                }
            }
        }
    };

        public async Task<Customer?> GetCustomerByAccountNumberAsync(string accountNumber)
        {
            return await Task.FromResult(_customers.FirstOrDefault(c => c.AccountNumber == accountNumber));
        }
    }
}
