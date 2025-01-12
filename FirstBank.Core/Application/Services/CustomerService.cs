using FirstBank.Core.Application.Interfaces.Repositories;
using FirstBank.Core.Application.Interfaces.Services;
using FirstBank.Core.Application.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstBank.Core.Application.Services
{
    public class CustomerService : IGetCustomerFields
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<CustomerFieldsDTO> ExecuteAsync(string accountNumber)
        {
            var customer = await _customerRepository.GetCustomerByAccountNumberAsync(accountNumber);

            if (customer == null)
            {
                return null;
            }

            return new CustomerFieldsDTO
            {
                AccountName = customer.Name,
                AccountNumber = customer.AccountNumber,
                Industry = customer.Industry.Name,
                Fields = customer.Industry.RequiredFields.Select(rf => rf.FieldName).ToList()
            };
        }
    }
}
