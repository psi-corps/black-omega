using System.Threading;
using System.Threading.Tasks;

namespace BlackOmega.Querying.IdentityMap
{
    public abstract class IdentityMapBase<TId, TEntity> : IIdentityMap<TId, TEntity> where TEntity : Entity<TId>
    {
        private readonly IIdentityMap<TId, TEntity> _backingMap;


        protected IdentityMapBase(IIdentityMap<TId, TEntity> backingMap = null) =>
            _backingMap = backingMap ?? NullIdentityMap<TId, TEntity>.Instance;


        protected abstract ValueTask<TEntity> Get(TId id, CancellationToken ct);

        protected abstract ValueTask Put(TId id, TEntity entity, CancellationToken ct);
        
        
        public async ValueTask<TEntity> GetById(TId id, CancellationToken ct = default)
        {
            var result = await Get(id, ct);

            if (result != null)
                return result;

            result = await _backingMap.GetById(id, ct);

            if (result == null)
                return null;

            Put(id, result, ct);

            return result;

        }
    }
}