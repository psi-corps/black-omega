namespace BlackOmega.Ordering.Storage.Orders
{
    /// <summary>
    /// The create order (command).
    /// </summary>
    /// <typeparam name="TEntity">The entity type.</typeparam>
    /// <typeparam name="TUser">The appliction user type.</typeparam>
    public class CreateOrder<TEntity, TUser> : Order<TUser> where TEntity : class
    {
        #region Constructor
        
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateOrder{TEntity,TUser}"/> type.
        /// </summary>
        /// <param name="source">The order source.</param>
        /// <param name="caller">The context application user.</param>
        public CreateOrder(string source, TUser caller) : base(source, caller) { }
        
        #endregion
        
        #region Properties
        
        /// <summary>
        /// Gets or sets the entity.
        /// </summary>
        public TEntity Entity { get; set; }
        
        #endregion
    }


    
    /// <inheritdoc />
    /// <summary>
    /// The create order (command).
    /// Must be used when you have to use DTO instead of entity. 
    /// </summary>
    /// <typeparam name="TEntity">The entity type.</typeparam>
    /// <typeparam name="TDto">The dto type.</typeparam>
    /// <typeparam name="TUser">The application user type.</typeparam>
    public class CreateOrder<TEntity, TDto, TUser> : CreateOrder<TEntity, TUser>
        where TEntity : class
        where TDto : class
    {
        #region Constructor
        
        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:BlackOmega.Ordering.Storage.Orders.CreateOrder`3" /> type.
        /// </summary>
        /// <param name="source">The order source.</param>
        /// <param name="caller">The context application user.</param>
        /// <param name="dto">The DTO.</param>
        public CreateOrder(string source, TUser caller, TDto dto) : base(source, caller) => Dto = dto;
        
        #endregion
        
        #region Properties
        
        /// <summary>
        /// Gets the DTO.
        /// </summary>
        public TDto Dto { get; }
        
        #endregion
    }
}