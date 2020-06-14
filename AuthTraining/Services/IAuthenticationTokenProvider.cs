using WeatherForecast.Contracts.Models;

namespace AuthTraining.Services
{
    public interface IAuthenticationTokenProvider
    {
        string GenerateToken(User user);
    }
}
