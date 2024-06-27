using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace Estudos.CrossCutting.IoC.Middlewares
{
    public class EnvironmentMiddleware : IMiddleware
    {
        private readonly ILogger<EnvironmentMiddleware> _logger;

        public EnvironmentMiddleware
        (
            ILogger<EnvironmentMiddleware> logger
        )
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch ( Exception ex )
            {
                _logger.LogError($"Error: {ex}", ex.Message);
                context.Response.StatusCode =
                    (int)HttpStatusCode.InternalServerError;

                ProblemDetails problem = new()
                {
                    Status = (int)HttpStatusCode.InternalServerError,
                    Type = "Server error",
                    Title = "Server error",
                    Detail = "An internal server has occured"
                };

                string json = JsonConvert.SerializeObject(problem);
                await context.Response.WriteAsync(json);
                context.Response.ContentType = "application/json";
            }
        }
    }
}

