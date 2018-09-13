namespace BlackOmega.Ordering.EntityFrameworkCore
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    
    using Microsoft.EntityFrameworkCore;

    using ExceptionHandling;
    using Notifications;

    
    public abstract class EntityFrameworkCoreOrderExecutorBase<TOrder> : IOrderExecutor<TOrder>
        where TOrder : Order
    {
        private readonly DbContextOptions _contextOptions;
        private readonly IExceptionHandler _exceptionHandler;
        private readonly INotifier<TOrder> _notifier;

        
        protected EntityFrameworkCoreOrderExecutorBase(DbContextOptions contextOptions,
            IExceptionHandler exceptionHandler, INotifier<TOrder> notifier)
        {
            _contextOptions = contextOptions;
            _exceptionHandler = exceptionHandler;
            _notifier = notifier;
        }


        protected abstract Task<IOrderStatus> Execute(DbContext context, TOrder order, User initiator,
            CancellationToken ct);
        

        public async Task<IOrderStatus> ExecuteOrder(TOrder order, User initiator, CancellationToken ct = default)
        {
            IOrderStatus contextStatus = default;
        
            try
            {
                IOrderStatus status;
                
                using (var ctx = new DbContext(_contextOptions))
                {
                    status = await Execute(ctx, order, initiator, ct);
                }

                return status ?? new OrderSuccessStatus();
            }
            catch (Exception x)
            {
                contextStatus = new OrderFailedStatus(x);

                if (await _exceptionHandler.HandleException(x))
                    return contextStatus;

                throw;
            }
            finally
            {
                await _notifier.NotifyCommandExecuted(order, initiator, contextStatus);
            }
        }
    }
}