namespace BlackOmega.Ordering
{
    /// <summary>
    /// The basic order without any arguments.
    /// Represents the "command" from the CQRS principle.
    /// </summary>
    public class Order
    {
        #region Constructor
        
        /// <summary>
        /// Initializes a new instance of the <see cref="Order"/> type.
        /// </summary>
        /// <param name="orderId">The order id.</param>
        /// <param name="serviceId">The source of the order.</param>
        public Order(string orderId, string serviceId)
        {
            OrderId = orderId;
            ServiceId = serviceId;
        }
        
        #endregion
        
        #region Properties
        
        /// <summary>
        /// Gets the order id.
        /// </summary>
        public string OrderId { get; set; }


        /// <summary>
        /// Gets the id of the service which sent the order.
        /// </summary>
        public string ServiceId { get; set; }

        #endregion
    }
}