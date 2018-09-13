using System;
using System.Threading;
using System.Threading.Tasks;

namespace BlackOmega.Querying.IdentityMap
{
    public interface IIdentityMap<in TId, TEntity> where TEntity : Entity<TId>
    {
        ValueTask<TEntity> GetById(TId id, CancellationToken ct = default);

        ValueTask<TProjection> GetById<TProjection>(TId id, Func<TEntity, TProjection> mapper,
            CancellationToken ct = default);
    }
}