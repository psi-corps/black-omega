using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PsiCorps.BlackOmega.IdentityMap.InMemory
{
    public class InMemoryIdentityMapEngine<TEntity, TId> : IIdentityMapEngine<TEntity, TId>
        where TEntity : class
    {
        // TODO: Data races (?)
        private readonly IDictionary<TId, TEntity> _map = new Dictionary<TId, TEntity>();



        public Task<TEntity> GetById(TId id, CancellationToken ct) =>
            Task.FromResult(_map.TryGetValue(id, out var entity) ? entity : null);

        public Task Update(TId id, TEntity result, CancellationToken ct)
        {
            _map[id] = result;
            return Task.CompletedTask;
        }
        
        public Task Invalidate(TId id, CancellationToken ct)
        {
            _map.Remove(id);
            return Task.CompletedTask;
        }
    }
}
