using FirstBank.Core.Application.Interfaces.HTTPService;
using FirstBank.Core.Application.Interfaces.Repositories;
using FirstBank.Core.Application.Services;
using FirstBank.Core.Infrastructure.HTTPServices;
using FirstBank.Core.Infrastructure.Persistence;
using FirstBank.Core.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstBank.Core.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddApiInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<ICustomerRepository, CustomerRepository>();

            return services;
        }

        public static IServiceCollection AddCustomerDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CustomerContext>(option =>
              option.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            return services;
        }

        public static IServiceCollection AddWebAppBackendBaseUrl(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient<IGetCustomerFields, ApiCustomerDataService>(client =>
            {
                client.BaseAddress = new Uri(configuration["ApiBaseUrl"] ?? "http://localhost:5000");
            });

            return services;
        }
    }
}
