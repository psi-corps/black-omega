namespace BlackOmega.DataAccess
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    
    /// <inheritdoc />
    /// <summary>
    /// An interface to the storage context.
    /// Can persist the storage state.
    /// </summary>
    public interface IStorageContext : IDisposable
    {
        /// <summary>
        /// Saves the storage state.
        /// </summary>
        /// <param name="ct">The cancellation token.</param>
        Task Save(CancellationToken ct = default);

        
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        IRepository<T> Repository<T>() where T : IEntity;
    }
}