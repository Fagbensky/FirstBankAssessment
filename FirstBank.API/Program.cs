
using FirstBank.API.Endpoints;
using FirstBank.API.Filters;
using FirstBank.Core.Application;
using FirstBank.Core.Infrastructure;
using System.Diagnostics;

namespace FirstBank.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var configuration = builder.Configuration;

            // Add services to the container.
            builder.Services.AddAuthorization();
            builder.Services.AddAApplicationServices();
            builder.Services.AddApiInfrastructureServices();
            builder.Services.AddCustomerDbContext(configuration);

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization(); 
            app.Use(async (context, next) =>
            {
                context.Response?.Headers?.Append("RequestId", Activity.Current?.TraceId.ToString());
                await next();
            });

            app.MapGroup("/v1")
            .RegisterCustomerRoutes()
            .AddEndpointFilter<ExceptionFilter>();

            app.Run();
        }
    }
}
