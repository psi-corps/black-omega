namespace BlackOmega.Ordering.Storage
{
    using System;
    
    
    /// <inheritdoc />
    /// <summary>
    /// The entity save order.
    /// </summary>
    /// <typeparam name="TId">The entity id type.</typeparam>
    /// <typeparam name="TEntity">The entity type.</typeparam>
    public class SaveAsOrder<TId, TEntity> : Order where TEntity : Entity<TId>
    {
        #region Constructor
        
        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:BlackOmega.Ordering.Storage.SaveOrder`2" /> type.
        /// </summary>
        /// <param name="orderId">The order id.</param>
        /// <param name="serviceId">The service id.</param>
        /// <param name="targetId">The target entity id.</param>
        /// <param name="entity">The entity.</param>
        public SaveAsOrder(string orderId, string serviceId, TId targetId, TEntity entity) : base(orderId, serviceId)
        {
            TargetId = targetId;
            Entity = entity ?? throw new ArgumentNullException(nameof(entity));
        }

        #endregion
        
        #region Properties
        
        /// <summary>
        /// Gets the target id.
        /// </summary>
        public TId TargetId { get; }
        
        
        /// <summary>
        /// Gets the entity.
        /// </summary>
        public TEntity Entity { get; }
        
        #endregion
    }
}