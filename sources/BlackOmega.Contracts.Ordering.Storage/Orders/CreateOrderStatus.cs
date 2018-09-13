namespace BlackOmega.Ordering.Storage.Orders
{
    using System;
    using System.ComponentModel.DataAnnotations;

    
    /// <summary>
    /// The status of the create order.
    /// </summary>
    /// <typeparam name="TEntity">The entity type.2</typeparam>
    public readonly struct CreateOrderStatus<TEntity> where TEntity : class
    {
        private const int BadRequestCode = 400;
        private const int ErrorCode = 500;
        private const int CreatedCode = 201;

        
        private readonly object _data;


        internal CreateOrderStatus(object data) => _data = data;


        public int? Code => Entity != null ? CreatedCode :
            Error != null ? ErrorCode :
            ValidationErrors != null ? BadRequestCode : (int?) null;  

        public Exception Error => _data as Exception;

        public TEntity Entity => _data as TEntity;

        public ValidationResult ValidationErrors => _data as ValidationResult;
    }
}