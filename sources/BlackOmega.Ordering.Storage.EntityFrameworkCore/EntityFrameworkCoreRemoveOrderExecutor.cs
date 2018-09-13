using System.Threading;
using System.Threading.Tasks;
using BlackOmega.ExceptionHandling;
using BlackOmega.Ordering.EntityFrameworkCore;
using BlackOmega.Ordering.Notifications;
using Microsoft.EntityFrameworkCore;

namespace BlackOmega.Ordering.Storage.EntityFrameworkCore
{
    public class EntityFrameworkCoreRemoveOrderExecutor<TId, TEntity, TInitiator> : EntityFrameworkCoreOrderExecutorBase<RemoveOrder<TId>, TInitiator, IOrderStatus> where TEntity : class
    {
        public EntityFrameworkCoreRemoveOrderExecutor(DbContextOptions contextOptions, IExceptionHandler exceptionHandler, INotifier<RemoveOrder<TId>, TInitiator> notifier) : base(contextOptions, exceptionHandler, notifier)
        {
        }


        protected virtual Task BeforeRemove(TEntity entity, TInitiator initiator,
            CancellationToken ct) => Task.CompletedTask;
        
        
        protected sealed override async Task<IOrderStatus> Execute(DbContext context, RemoveOrder<TId> order, TInitiator initiator, CancellationToken ct)
        {
            var target = await context.FindAsync<TEntity>(order.TargetId);

            if (target == null)
                return new OrderTargetNotFoundStatus();

            await BeforeRemove(target, initiator, ct);

            context.Remove(target);
            
            return new OrderSuccessStatus();
        }
    }
}