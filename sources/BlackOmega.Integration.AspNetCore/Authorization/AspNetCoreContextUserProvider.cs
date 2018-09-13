using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace BlackOmega.Integration.AspNetCore.Authorization
{
    public class AspNetCoreContextUserProvider : IAspNetCoreContextUserProvider
    {
        public ValueTask<User> GetContextUser(HttpContext context, CancellationToken ct) =>
            new ValueTask<User>(new AspNetCoreUser(context.User));
    }
}