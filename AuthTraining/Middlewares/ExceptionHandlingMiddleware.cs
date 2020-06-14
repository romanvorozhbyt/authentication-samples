using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Threading.Tasks;
using WeatherForecast.Contracts.Exceptions;
using WeatherForecastApi.Models.ExceptionHandling;

namespace WeatherForecastApi.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        
        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {
                // Log exception
                await HandleExceptionAsync(context, exception);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var errorResponse = new ErrorResponse();
            if (exception is HttpException httpException)
            {
                errorResponse.StatusCode = httpException.StatusCode;
                errorResponse.Message = httpException.Message;
            }
            else if (exception is InvalidInboundException inboundException)
            {
                errorResponse.StatusCode = HttpStatusCode.BadRequest;
                errorResponse.Message = inboundException.Message;
                errorResponse.AdditionalParameters = new { inboundException.ParamName };
            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)errorResponse.StatusCode;
            await context.Response.WriteAsync(errorResponse.ToJsonString());
        }
    }
}
