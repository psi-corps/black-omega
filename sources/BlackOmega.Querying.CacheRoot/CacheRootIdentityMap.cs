using System.Threading;
using System.Threading.Tasks;

namespace BlackOmega.Querying.CacheRoot
{
    public class CacheRootIdentityMap<TId, TEntity> : IdentityMapBase<TId, TEntity> where TEntity : Entity<TId>
    {
        protected override ValueTask<TEntity> Get(TId id, CancellationToken ct)
        {
            throw new System.NotImplementedException();
        }

        protected override ValueTask Put(TId id, TEntity entity, CancellationToken ct)
        {
            throw new System.NotImplementedException();
        }
    }
}