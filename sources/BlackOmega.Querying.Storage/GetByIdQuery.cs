namespace BlackOmega.Querying
{
    public class GetByIdQuery<TId> : Query
    {
        public TId Id { get; }
    }
}