namespace BlackOmega.Ordering.Storage
{
    public class UpdateOrder<TId, TEntity, TDto> : Order
    {
        public UpdateOrder(string orderId, string serviceId, TId targetId, TDto dto) : base(orderId, serviceId)
        {
            TargetId = targetId;
            Dto = dto;
        }
        
        
        public TId TargetId { get; }
        
        public TDto Dto { get; }
    }
}