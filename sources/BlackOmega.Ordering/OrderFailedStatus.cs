namespace BlackOmega.Ordering
{
    using System;
    
    
    /// <inheritdoc />
    /// <summary>
    /// The status marks the failed order.
    /// </summary>
    public sealed class OrderFailedStatus : IOrderStatus
    {
        #region Constructor
        
        /// <summary>
        /// Initializes a new instance of the <see cref="OrderFailedStatus"/> type.
        /// </summary>
        /// <param name="fail">The exception.</param>
        public OrderFailedStatus(Exception fail) => Fail = fail;
        
        #endregion
        
        #region Properties
        
        /// <summary>
        /// Gets the exception.
        /// </summary>
        public Exception Fail { get; }
        
        #endregion
    }
}