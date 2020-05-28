using AuthTraining.Models;
using System.Collections.Generic;
using System.Linq;

namespace AuthTraining.Services
{
    public class IdentityProvider : IIdentityProvider
    {
        private readonly IAuthenticationTokenProvider _tokenProvider;

        public IdentityProvider(IAuthenticationTokenProvider tokenProvider)
        {
            _tokenProvider = tokenProvider;
        }

        private List<User> appUsers = new List<User>
        {
            new User { FullName = "Vaibhav Bhapkar", UserName = "admin", Password = "1234", UserRole = "Admin" },
            new User { FullName = "Test User", UserName = "user", Password = "1234", UserRole = "User" }
        };

        public string AuthenticateUser(string userName, string password)
        {
            User user = appUsers.SingleOrDefault(x => x.UserName == userName && x.Password == password);
            
            return _tokenProvider.GenerateToken(user);
        }

        public bool ValidateToken(string token)
        {
            throw new System.NotImplementedException();
        }
    }
}
