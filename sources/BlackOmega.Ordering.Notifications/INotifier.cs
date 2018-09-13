namespace BlackOmega.Ordering.Notifications
{
    using System.Threading.Tasks;
    
    
    /// <summary>
    /// An interface to the order execution notifier.
    /// Publishes the message
    /// </summary>
    /// <typeparam name="TOrder">The order type.</typeparam>
    public interface INotifier<in TOrder>
    {
        /// <summary>
        /// Notifies system components about command executed.
        /// </summary>
        /// <param name="order">The order.</param>
        /// <param name="initiator">The context application user.</param>
        /// <param name="status">The status.</param>
        ValueTask NotifyCommandExecuted(TOrder order, User initiator, IOrderStatus status);
    }
}