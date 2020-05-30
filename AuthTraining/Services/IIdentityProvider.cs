namespace AuthTraining.Services
{
    public interface IIdentityProvider
    {
        string AuthenticateUser(string userName, string password);  
    }
}
