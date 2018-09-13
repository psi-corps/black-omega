using System.Security.Claims;

namespace BlackOmega.Integration.AspNetCore.Authorization
{
    public class AspNetCoreUser : User
    {
        public AspNetCoreUser(ClaimsPrincipal principal) => Principal = principal;
        
        public ClaimsPrincipal Principal { get; }
    }
}