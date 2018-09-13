using System.Threading;
using System.Threading.Tasks;
using BlackOmega.ExceptionHandling;
using BlackOmega.Ordering.EntityFrameworkCore;
using BlackOmega.Ordering.Notifications;
using Microsoft.EntityFrameworkCore;

namespace BlackOmega.Ordering.Storage.EntityFrameworkCore
{
    public class EntityFrameworkCoreSaveOrderExecutor<TId, TEntity> : EntityFrameworkCoreOrderExecutorBase<SaveOrder<TId, TEntity>, IOrderStatus> where TEntity : Entity<TId>
    {
        public EntityFrameworkCoreSaveOrderExecutor(DbContextOptions contextOptions,
            IExceptionHandler exceptionHandler, INotifier<SaveOrder<TId, TEntity>> notifier) :
            base(contextOptions, exceptionHandler, notifier) { }


        protected virtual Task BeforeSave(DbContext context, TEntity entity, User initiator,
            CancellationToken ct) => Task.CompletedTask;
        
        
        protected sealed override async Task<IOrderStatus> Execute(DbContext context, SaveOrder<TId, TEntity> order, User initiator, CancellationToken ct)
        {
            await BeforeSave(context, order.Entity, initiator, ct);
            
            context.Add(order.Entity);
            
            return new SaveOrderSuccessStatus<TId>(order.Entity.Id);
        }
    }
}