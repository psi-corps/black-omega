namespace BlackOmega.Ordering.Storage
{
    public class SaveOrderSuccessStatus<TId> : IOrderStatus
    {
        public SaveOrderSuccessStatus(TId id)
        {
            
        }
        
        
        public TId Id { get; }
    }
}