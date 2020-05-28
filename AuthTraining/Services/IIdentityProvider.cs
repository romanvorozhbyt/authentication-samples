using AuthTraining.Models;

namespace AuthTraining.Services
{
    public interface IIdentityProvider
    {
        string AuthenticateUser(string userName, string password);

        bool ValidateToken(string token);
    }
}
