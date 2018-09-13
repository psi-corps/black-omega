using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace BlackOmega.Integration.AspNetCore.Authorization
{
    public interface IAspNetCoreContextUserProvider
    {
        ValueTask<User> GetContextUser(HttpContext context, CancellationToken ct);
    }
}