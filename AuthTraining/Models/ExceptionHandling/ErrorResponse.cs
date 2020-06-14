using Newtonsoft.Json;
using System.Net;

namespace WeatherForecastApi.Models.ExceptionHandling
{
    public class ErrorResponse
    {
        public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.InternalServerError;

        public string Message { get; set; } = "An unexpected error occured";

        public string ToJsonString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
