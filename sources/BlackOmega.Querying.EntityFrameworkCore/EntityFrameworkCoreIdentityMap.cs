using System;
using System.Threading;
using System.Threading.Tasks;
using BlackOmega.Querying.IdentityMap;
using Microsoft.EntityFrameworkCore;

namespace BlackOmega.Querying.EntityFrameworkCore
{
    public class EntityFrameworkCoreIdentityMap<TId, TEntity> : IdentityMapBase<TId, TEntity>
        where TEntity : Entity<TId>
    {
        private readonly DbContextOptions _contextOptions;





        protected override async ValueTask<TEntity> Get(TId id, CancellationToken ct)
        {
            using (var ctx = new DbContext(_contextOptions))
            {
                return await ctx.FindAsync<TEntity>(new object[] {id}, ct);
            }
        }

        protected override async ValueTask Put(TId id, TEntity entity, CancellationToken ct)
        {
            using (var ctx = new DbContext(_contextOptions))
            {
                ctx.Attach(entity);
                ctx.Update(entity);

                await ctx.SaveChangesAsync(ct);
            }
        }
    }
}