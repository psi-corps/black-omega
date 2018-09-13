using System.Threading;
using System.Threading.Tasks;

namespace BlackOmega.Querying.IdentityMap
{
    public class NullIdentityMap<TId, TEntity> : IIdentityMap<TId, TEntity> where TEntity : Entity<TId>
    {
        public static readonly IIdentityMap<TId, TEntity> Instance = new IdentityMapBase<TId, TEntity>();
        
        
        public ValueTask<TEntity> GetById(TId id, CancellationToken ct = default) =>
            new ValueTask<TEntity>((TEntity) null);
    }
}