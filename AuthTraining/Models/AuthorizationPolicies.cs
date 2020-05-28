using Microsoft.AspNetCore.Authorization;

namespace AuthTraining.Models
{
    public class AuthorizationPolicies
    {
        public const string User = "User";

        public const string Admin = "Admin";

        public static AuthorizationPolicy UserPolicy()
        {
            return new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .RequireRole(User)
                .Build();
        }

        public static AuthorizationPolicy AdminPolicy()
        {
            return new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .RequireRole(Admin)
                .Build();
        }
    }
}
