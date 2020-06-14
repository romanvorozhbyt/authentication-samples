using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using System.Net;
using WeatherForecast.Contracts.Exceptions;
using WeatherForecastApi.Models.ExceptionHandling;

namespace WeatherForecastApi.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseNativeGlobalExceptionHandling(this IApplicationBuilder builder)
        {
            builder.UseExceptionHandler(errorApp =>
            {
                errorApp.Run(async context =>
                {
                    var errorFeature = context.Features.Get<IExceptionHandlerFeature>();
                    var exception = errorFeature.Error;
                    var errorResponse = new ErrorResponse();
                    if (exception is HttpException httpException)
                    {
                        errorResponse.StatusCode = httpException.StatusCode;
                        errorResponse.Message = httpException.Message;
                    }
                    else if(exception is InvalidInboundException inboundException)
                    {
                        errorResponse.StatusCode = HttpStatusCode.BadRequest;
                        errorResponse.Message = inboundException.Message;
                        errorResponse.AdditionalParameters = new { inboundException.ParamName };
                    }
                    context.Response.StatusCode = (int)errorResponse.StatusCode;
                    context.Response.ContentType = "application/json";
                    await context.Response.WriteAsync(errorResponse.ToJsonString());
                });
            });
            return builder;
        }
    }
}
