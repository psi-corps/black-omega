namespace BlackOmega.Ordering
{
    /// <inheritdoc />
    /// <summary>
    /// The status marks success executed order.
    /// </summary>
    public sealed class OrderSuccessStatus : IOrderStatus
    {

    }
    
    
    /// <inheritdoc />
    /// <summary>
    /// The status marks success executed order.
    /// </summary>
    /// <typeparam name="T">The status value type.</typeparam>
    public sealed class OrderSuccessStatus<T> : IOrderStatus
    {
        #region Constructor
        
        /// <summary>
        /// Initializes a new instance of the <see cref="OrderSuccessStatus{T}"/> type.
        /// </summary>
        /// <param name="statusValue">The status value.</param>
        public OrderSuccessStatus(T statusValue) => StatusValue = statusValue;

        #endregion
        
        #region Properties
        
        /// <summary>
        /// Gets the value.
        /// </summary>
        public T StatusValue { get; }
        
        #endregion
    }
}