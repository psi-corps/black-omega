using System.Threading;
using System.Threading.Tasks;

namespace PsiCorps.BlackOmega.IdentityMap
{
    public interface IIdentityMapEngine<TEntity, TId>
    {
        Task<TEntity> GetById(TId id, CancellationToken ct);

        Task Update(TId id, TEntity result, CancellationToken ct);

        Task Invalidate(TId id, CancellationToken ct);
    }
}