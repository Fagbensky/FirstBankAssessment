using FirstBank.Core.Application.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace FIrstBank.WebApp.Pages
{
    public class ConfirmationModel : PageModel
    {
        public Dictionary<string, string> InputValues { get; set; }
        public CustomerFieldsDTO CustomerFields { get; set; }

        public IActionResult OnGet()
        {
            if (TempData.ContainsKey("InputValues") && TempData.ContainsKey("CustomerFields"))
            {
                InputValues = JsonSerializer.Deserialize<Dictionary<string, string>>((string)TempData["InputValues"]!);
                CustomerFields = JsonSerializer.Deserialize<CustomerFieldsDTO>((string)TempData["CustomerFields"]!);
                return Page();
            }

            return RedirectToPage("./Transaction"); // Redirect if no data is available
        }
    }
}
