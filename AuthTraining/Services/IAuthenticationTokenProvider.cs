using AuthTraining.Models;

namespace AuthTraining.Services
{
    public interface IAuthenticationTokenProvider
    {
        string GenerateToken(User user);

        bool ValidateToken(string token);
    }
}
