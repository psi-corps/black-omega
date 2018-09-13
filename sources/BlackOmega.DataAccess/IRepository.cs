namespace BlackOmega.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Threading;
    using System.Threading.Tasks;

    
    /// <summary>
    /// An interface to the repository.
    /// Repository is a generic entity collection which provides access to the <typeparam name="TEntity"/> type.
    /// It doesn't save the storage state.
    /// </summary>
    /// <typeparam name="TId">The entity ide type.</typeparam>
    /// <typeparam name="TEntity">The entity type.</typeparam>
    public interface IRepository<in TId, TEntity> where TEntity : IEntity
    {
        /// <summary>
        /// Adds a new <paramref name="entity"/> to the collection.
        /// If the entity has an id, updates the entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Save(TEntity entity);

        
        /// <summary>
        /// Removes the <paramref name="entity"/> from the collection.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Remove(TEntity entity);
        
        
        /// <summary>
        /// Gets the entity by it's <paramref name="id"/>.
        /// </summary>
        /// <param name="id">The target id.</param>
        /// <param name="ct">The cancellation token.</param>
        /// <returns>
        /// An instance of the <see cref="TEntity"/> type.
        /// If the entity wasn't found returns <langword name="null"/>
        /// </returns>
        Task<TEntity> GetById(TId id, CancellationToken ct = default);
        
        
        /// <summary>
        /// Gets the list of entities which satisfy the <paramref name="filter"/>.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <param name="ct">The cancellation token.</param>
        /// <returns>
        /// The <see cref="IReadOnlyList{TEntity}"/>.
        /// Returns an empty list if there are no entities satisfies the <paramref name="filter"/>.
        /// </returns>
        Task<IReadOnlyList<TEntity>> Get(Expression<Func<TEntity, bool>> filter, CancellationToken ct = default);


// TODO: To research about async queryable.
//        Task<IReadOnlyList<TProjection>> Query<TProjection>(IQueryable<TEntity> query,
//            Expression<Func<TEntity, TProjection>> map, CancellationToken ct = default);
    }
}