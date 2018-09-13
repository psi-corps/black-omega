namespace BlackOmega.Ordering.EntityFramework
{
    using System;
    using System.Data.Entity;
    using System.Threading;
    using System.Threading.Tasks;
    
    using ExceptionHandling;
    using Notifications;
    
    
    public abstract class EntityFrameworkCoreOrderExecutorBase<TOrder, TInitiator, TStatus> : IOrderExecutor<TOrder, TInitiator, IOrderStatus>
        where TOrder : Order
    {
        private readonly string _connectionString;
        private readonly IExceptionHandler _exceptionHandler;
        private readonly INotifier<TOrder, TInitiator> _notifier;

        protected EntityFrameworkCoreOrderExecutorBase(string connectionString, IExceptionHandler exceptionHandler,
            INotifier<TOrder, TInitiator> notifier)
        {
            _connectionString = connectionString;
            _exceptionHandler = exceptionHandler;
            _notifier = notifier;
        }


        protected abstract Task<TStatus> Execute(DbContext context, TOrder order, TInitiator initiator,
            CancellationToken ct);
        

        public async Task<IOrderStatus> ExecuteOrder(TOrder order, TInitiator initiator, CancellationToken ct = default)
        {
            IOrderStatus contextStatus = default;
        
            try
            {
                TStatus statusObject;
                
                using (var ctx = new DbContext(_connectionString))
                {
                    statusObject = await Execute(ctx, order, initiator, ct);
                }

                contextStatus = new OrderSuccessStatus<TStatus>(statusObject);

                return contextStatus;
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