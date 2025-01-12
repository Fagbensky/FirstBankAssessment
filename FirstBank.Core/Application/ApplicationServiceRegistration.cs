using FirstBank.Core.Application.Interfaces.Services;
using FirstBank.Core.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FirstBank.Core.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddAApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IGetCustomerFields, CustomerService>();

            return services;
        }
    }
}
