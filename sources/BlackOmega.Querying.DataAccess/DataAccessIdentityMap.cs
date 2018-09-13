using System.Threading;
using System.Threading.Tasks;
using BlackOmega.DataAccess;

namespace BlackOmega.Querying.DataAccess
{
    public class DataAccessIdentityMap<TId, TEntity> : IdentityMapBase<TId, TEntity> where TEntity : Entity<TId>
    {
        private readonly IStorageContextFactory _storageFactory;
        
        
        protected override ValueTask<TEntity> Get(TId id, CancellationToken ct)
        {
            using (var storage = _storageFactory.CreateContext())
            {
                return storage.Repository<TEntity>().GetById(id, ct);
            }
        }

        
        protected override ValueTask Put(TId id, TEntity entity, CancellationToken ct) => new ValueTask();
    }
}