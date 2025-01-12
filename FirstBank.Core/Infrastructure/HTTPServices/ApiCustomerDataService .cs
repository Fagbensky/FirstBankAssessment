using FirstBank.Core.Application.Interfaces.HTTPService;
using FirstBank.Core.Domain.DTOs;
using FirstBank.Core.Domain.ViewModels;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
namespace FirstBank.Core.Infrastructure.HTTPServices
{
    public class ApiCustomerDataService: IGetCustomerFields
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<ApiCustomerDataService> _logger;

        public ApiCustomerDataService(HttpClient httpClient, ILogger<ApiCustomerDataService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<CustomerFieldsDTO?> GetCustomerFieldsAsync(string accountNumber)
        {
            var response = await _httpClient.GetAsync($"/v1/customer/fields/{accountNumber}");

            if (response.IsSuccessStatusCode)
            {
                var responseData = await response.Content.ReadFromJsonAsync<BaseResponse<CustomerFieldsDTO>>();
                if (responseData != null && responseData.Status)
                {
                    return responseData.Data;
                }

                _logger.LogError($"API Error: {response.StatusCode}. \n Details: {JsonSerializer.Serialize(responseData)}");
                return null;
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {

                _logger.LogError($"API Error: {response.StatusCode}. \n Details: {JsonSerializer.Serialize(response)}");
                return null; // Handle not found gracefully
            }
            else
            {

                _logger.LogError($"API Error: {response.StatusCode}. \n Details: {JsonSerializer.Serialize(response)}");
                return null; // Or throw an exception
            }
        }
    }
}
