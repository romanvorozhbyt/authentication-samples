using WeatherForecast.Data.Models;

namespace AuthTraining.Services
{
    public interface IAuthenticationTokenProvider
    {
        string GenerateToken(User user);
    }
}
