namespace BlackOmega.Ordering.Storage
{
    public class SavedOrderStatus<TId> : StorageOrderStatus
    {
        public SavedOrderStatus(TId id) => Id = id;


        public TId Id { get; set; }
    }
}