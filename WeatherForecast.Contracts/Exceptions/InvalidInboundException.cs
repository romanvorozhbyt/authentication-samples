using System;

namespace WeatherForecast.Contracts.Exceptions
{
    public class InvalidInboundException : ArgumentException
    {
        public InvalidInboundException(string message, string paramName) : base(message, paramName) {}
    }
}
