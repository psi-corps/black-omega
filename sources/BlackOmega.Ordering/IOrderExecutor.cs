namespace BlackOmega.Ordering
{
    using System.Threading;
    using System.Threading.Tasks;
    
    
    /// <summary>
    /// An interface to the order executor.
    /// Must be implemented for each order only once.
    /// Can be generically implemented to use one implementation for several orders.
    /// An example of the generic implementation you can find in the BlackOmega.Ordering.Storage.EntityFrameworkCore.
    /// </summary>
    /// <typeparam name="TOrder">The order type.</typeparam>
    public interface IOrderExecutor<in TOrder> where TOrder : Order
    {
        /// <summary>
        /// Executes the <paramref name="order"/>.
        /// </summary>
        /// <param name="order">The order to execute.</param>
        /// <param name="initiator">The context application user.</param>
        /// <param name="ct">The cancellation token.</param>
        /// <returns>
        /// The status.
        /// Used by the underlying application layer to build the negotiation.
        /// </returns>
        Task<IOrderStatus> ExecuteOrder(TOrder order, User initiator, CancellationToken ct = default);
    }
}