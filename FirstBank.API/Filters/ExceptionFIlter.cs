using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;
using System.Text.Json;
using FirstBank.Core.Application.Models.ViewModels;

namespace FirstBank.API.Filters
{
    public class ExceptionFilter : IEndpointFilter
    {
        private readonly ILogger<ExceptionFilter> _logger;
        public ExceptionFilter(ILogger<ExceptionFilter> logger)
        {
            _logger = logger;
        }
        public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
        {
            try
            {
                return await next(context);
            }
            catch (Exception exception)
            {
                _logger.LogError($"An error occured: {exception.Message}. \n Details: {JsonSerializer.Serialize(new Error(exception))}");
                return Results.Json(new BaseResponse(false, "An error occured"), statusCode: StatusCodes.Status500InternalServerError);
            }
        }
    }

    [Serializable]
    public class Error
    {
        public DateTime TimeStamp { get; set; }
        public string Message { get; set; }
        public string StackTrace { get; set; }

        public Error()
        {
            this.TimeStamp = DateTime.Now;
        }

        public Error(string Message) : this()
        {
            this.Message = Message;
        }

        public Error(System.Exception ex) : this(ex.Message)
        {
            this.StackTrace = ex.StackTrace;
        }

        public override string ToString()
        {
            return this.Message + this.StackTrace;
        }
    }
}
