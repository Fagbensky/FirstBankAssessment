using FirstBank.Core.Application.Interfaces.HTTPService;
using FirstBank.Core.Domain.Constants;
using FirstBank.Core.Domain.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace FIrstBank.WebApp.Pages
{
    public class TransactionModel : PageModel
    {

        private readonly IGetCustomerFields _getCustomerFieldsUseCase;

        public TransactionModel(IGetCustomerFields getCustomerFieldsUseCase)
        {
            _getCustomerFieldsUseCase = getCustomerFieldsUseCase;
        }

        [BindProperty(SupportsGet = true)]
        public string AccountNumber { get; set; }
        public CustomerFieldsDTO? CustomerFields { get; set; }
        [BindProperty]
        public Dictionary<string, string> InputValues { get; set; } = new();
        public string ErrorMessage { get; set; }

        public async Task OnGet()
        {
            if (!string.IsNullOrEmpty(AccountNumber))
            {
                CustomerFields = await _getCustomerFieldsUseCase.GetCustomerFieldsAsync(AccountNumber);
                if (CustomerFields == null)
                {
                    ErrorMessage = "Account not found.";
                    return;
                }
                InputValues = CustomerFields.Fields.ToDictionary(f => f, f => "");
                HttpContext.Session.SetString(SessionKeys.CUSTOMER_FIELDS, JsonSerializer.Serialize(CustomerFields));
            }
        }

        public IActionResult OnPost()
        {
            var customerFieldsJson = HttpContext.Session.GetString("CustomerFields");

            if(!string.IsNullOrEmpty(customerFieldsJson)) CustomerFields = JsonSerializer.Deserialize<CustomerFieldsDTO>(customerFieldsJson);

            if (CustomerFields == null)
            {
                ErrorMessage = "Please provide an account number.";
                return Page();
            }

            if (InputValues.Any(kvp => string.IsNullOrEmpty(kvp.Value)))
            {
                ErrorMessage = "All fields are required.";
                return Page();
            }

            TempData["InputValues"] = System.Text.Json.JsonSerializer.Serialize(InputValues);
            TempData["CustomerFields"] = System.Text.Json.JsonSerializer.Serialize(CustomerFields);

            return RedirectToPage("./Confirmation");
        }
    }
}
