namespace BlackOmega.Ordering.Storage
{
    public class RemoveOrder<TId> : Order
    {
        public RemoveOrder(string orderId, string serviceId) : base(orderId, serviceId)
        {
        }
        
        
        public TId TargetId { get; }
    }
}