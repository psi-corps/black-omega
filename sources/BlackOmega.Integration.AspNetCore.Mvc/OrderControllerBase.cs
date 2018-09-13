namespace BlackOmega.Integration.AspNetCore.Mvc
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    
    using Microsoft.AspNetCore.Mvc;
    
    using Ordering;
    using Authorization;
    

    /// <inheritdoc />
    /// <summary>
    /// The base class for the order controller.
    /// </summary>
    /// <typeparam name="TOrder">The order type.</typeparam>
    public abstract class OrderControllerBase<TOrder> : ControllerBase where TOrder : Order
    {
        #region Dependencies
        
        protected readonly IActionResultProducer ResultProducer;
        protected readonly IAspNetCoreContextUserProvider UserProvider;
        protected readonly IOrderIdProducer OrderIdProducer;
        protected readonly ISeviceIdProvider ServiceIdProvider;

        #endregion
        
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderControllerBase{TOrder}"/> type.
        /// </summary>
        /// <param name="resultProducer">The result producer.</param>
        /// <param name="userProvider">The context user provider.</param>
        /// <param name="orderIdProducer">The order id producer.</param>
        /// <param name="serviceIdProvider">The service id provider.</param>
        protected OrderControllerBase(IActionResultProducer resultProducer, IAspNetCoreContextUserProvider userProvider,
            IOrderIdProducer orderIdProducer, ISeviceIdProvider serviceIdProvider)
        {
            ResultProducer = resultProducer ?? throw new ArgumentNullException(nameof(resultProducer));
            UserProvider = userProvider ?? throw new ArgumentNullException(nameof(userProvider));
            OrderIdProducer = orderIdProducer ?? throw new ArgumentNullException(nameof(orderIdProducer));
            ServiceIdProvider = serviceIdProvider ?? throw new ArgumentNullException(nameof(serviceIdProvider));
        }

        #endregion

        #region Action handlers

        /// <summary>
        /// Handles the <typeparamref name="TOrder"/> as a web request.
        /// </summary>
        /// <param name="executor">The executor.</param>
        /// <param name="order">The order.</param>
        /// <param name="ct">The cancellation token.</param>
        /// <returns>
        /// An instance of the <see cref="IActionResult"/> type.
        /// </returns>
        public virtual async Task<IActionResult> ExecuteOrder(IOrderExecutor<TOrder> executor,
            TOrder order, CancellationToken ct)
        {
            order.OrderId = OrderIdProducer.CreateOrderId();
            order.ServiceId = ServiceIdProvider.GetServiceId();
            
            var user = await UserProvider.GetContextUser(HttpContext, ct);
            var status = await executor.ExecuteOrder(order, user, ct);

            return ResultProducer.CreateResult(status);
        }
        
        #endregion
    }
}