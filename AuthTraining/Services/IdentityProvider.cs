using System.Linq;
using WeatherForecast.Data.NewFolder;

namespace AuthTraining.Services
{
    public class IdentityProvider : IIdentityProvider
    {
        private readonly IAuthenticationTokenProvider _tokenProvider;
        private readonly IUserProvider _userProvider;

        public IdentityProvider(IAuthenticationTokenProvider tokenProvider, IUserProvider userProvider)
        {
            _tokenProvider = tokenProvider;
            _userProvider = userProvider;
        }

        public string AuthenticateUser(string userName, string password)
        {
            var user = _userProvider.Search(x => x.UserName == userName && x.Password == password).FirstOrDefault();
            
            return _tokenProvider.GenerateToken(user);
        }
    }
}
