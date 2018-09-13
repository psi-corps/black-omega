namespace BlackOmega
{
    /// <summary>
    /// The basic entity.
    /// It just has an id.
    /// </summary>
    /// <typeparam name="TId">The id type.</typeparam>
    public abstract class Entity<TId>
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public TId Id { get; set; }
    }
}