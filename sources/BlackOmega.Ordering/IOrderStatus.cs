namespace BlackOmega.Ordering
{
    /// <summary>
    /// The basic order status marker.
    /// All the order executors must return an instance of this interface implementation.
    /// It uses by the underlying application layer fto build the negotiation.
    /// </summary>
    public interface IOrderStatus
    {
        
    }
}