using System.Threading;
using System.Threading.Tasks;
using BlackOmega.ExceptionHandling;
using BlackOmega.Ordering.EntityFrameworkCore;
using BlackOmega.Ordering.Notifications;
using Microsoft.EntityFrameworkCore;

namespace BlackOmega.Ordering.Storage.EntityFrameworkCore
{
    public class EntityFrameworkCoreSaveAsOrderExecutor<TId, TEntity, TInitiator> : EntityFrameworkCoreOrderExecutorBase<SaveAsOrder<TId, TEntity>, TInitiator, IOrderStatus> where TEntity : Entity<TId>
    {
        public EntityFrameworkCoreSaveAsOrderExecutor(DbContextOptions contextOptions,
            IExceptionHandler exceptionHandler, INotifier<SaveAsOrder<TId, TEntity>, TInitiator> notifier) :
            base(contextOptions, exceptionHandler, notifier) { }


        protected virtual Task BeforeSave(DbContext context, TEntity entity, TInitiator initiator,
            CancellationToken ct) => Task.CompletedTask;
        
        
        protected sealed override async Task<IOrderStatus> Execute(DbContext context, SaveAsOrder<TId, TEntity> order, TInitiator initiator, CancellationToken ct)
        {
            var target = context.FindAsync<TEntity>(order.TargetId);
            
            if (target == null)
                return new OrderTargetNotFoundStatus();

            order.Entity.Id = order.TargetId;
            
            await BeforeSave(context, order.Entity, initiator, ct);

            context.Attach(order.Entity);
            context.Update(order.Entity);
            
            return new SaveOrderSuccessStatus<TId>(order.Entity.Id);
        }
    }
}