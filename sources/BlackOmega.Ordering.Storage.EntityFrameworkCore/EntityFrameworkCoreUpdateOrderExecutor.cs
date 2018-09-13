using System.Threading;
using System.Threading.Tasks;
using BlackOmega.ExceptionHandling;
using BlackOmega.Ordering.EntityFrameworkCore;
using BlackOmega.Ordering.Notifications;
using Microsoft.EntityFrameworkCore;

namespace BlackOmega.Ordering.Storage.EntityFrameworkCore
{
    public class EntityFrameworkCoreUpdateOrderExecutor<TId, TEntity, TDto, TInitiator> :
        EntityFrameworkCoreOrderExecutorBase<UpdateOrder<TId, TEntity, TDto>, TInitiator, IOrderStatus>
    where TEntity : Entity<TId>
    {
        private readonly IEntityFiller<TEntity, TDto> _filler;
        
        
        public EntityFrameworkCoreUpdateOrderExecutor(DbContextOptions contextOptions,
            IExceptionHandler exceptionHandler, INotifier<SaveOrder<TId, TEntity>, TInitiator> notifier) :
            base(contextOptions, exceptionHandler, notifier) { }


        protected sealed override async Task<IOrderStatus> Execute(DbContext context, UpdateOrder<TId, TEntity, TDto> order, TInitiator initiator, CancellationToken ct)
        {
            var entity = await context.FindAsync<TEntity>(order.TargetId);

            await _filler.FillEntity(context, entity, order.Dto);
           
            return new SaveOrderSuccessStatus<TId>(entity.Id);
        }
    }

    internal interface IEntityFiller<TEntity, TDto>
    {
        Task FillEntity(DbContext context, TEntity entity, TDto orderDto);
    }
}