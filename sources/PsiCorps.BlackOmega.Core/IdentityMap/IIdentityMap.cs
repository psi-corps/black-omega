using System.Threading;
using System.Threading.Tasks;

namespace PsiCorps.BlackOmega.IdentityMap
{
    // TODO: REname this interface 
    public interface IIdentityMap<TEntity, TId>
    {
        Task<TEntity> GetById(TId id, CancellationToken ct);
    }
}