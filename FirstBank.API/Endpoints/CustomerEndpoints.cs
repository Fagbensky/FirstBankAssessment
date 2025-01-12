using FirstBank.Core.Application.Interfaces.Services;
using FirstBank.Core.Domain.DTOs;
using FirstBank.Core.Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FirstBank.API.Endpoints
{
    public static class CustomerEndpoints
    {
        public static RouteGroupBuilder RegisterCustomerRoutes(this RouteGroupBuilder group)
        {
            var adminRoute = group.MapGroup("/customer");

            adminRoute.MapGet("fields/{accountNumber}", GetCustomerFields)
                .WithName("GetCustomerFields")
                .Produces<BaseResponse<CustomerFieldsDTO>>(200)
                .Produces<BaseResponse>(404);

            return group;
        }

        /// <summary>
        /// Get Additional Fields for customer
        /// </summary>
        /// <param name="accountNumber">Account number to search Data</param>
        /// <returns>Aditional Fields for customer Transaction</returns>
        public static async Task<IResult> GetCustomerFields(string accountNumber, IGetCustomerFields getCustomerFieldsUseCase)
        {
            var response = await getCustomerFieldsUseCase.ExecuteAsync(accountNumber);

            return response?.Industry != null ? Results.Ok(new BaseResponse<CustomerFieldsDTO?>(true, "Customer Found successfuly.", response)) : Results.NotFound(new BaseResponse<CustomerFieldsDTO?>(false, "Customer Not Found."));
        }
    }
}
