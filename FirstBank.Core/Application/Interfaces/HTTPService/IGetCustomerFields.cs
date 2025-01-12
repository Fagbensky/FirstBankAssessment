﻿using FirstBank.Core.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstBank.Core.Application.Interfaces.HTTPService
{
    public interface IGetCustomerFields
    {
        Task<CustomerFieldsDTO?> GetCustomerFieldsAsync(string accountNumber);
    }
}