namespace PsiCorps.BlackOmega
{
    using System.Threading;
    using System.Threading.Tasks;

    using Results;


    public interface IStorage<TEntity, in TId, in TUserIdentity> where TEntity : class
    {
        Task<(Status, TEntity)> GetById(TId id, TUserIdentity uid, CancellationToken ct = default);

        Task<Result> Create(TEntity entity, TUserIdentity uid, CancellationToken ct = default);

        Task<Result> Update(TId id, TEntity entity, TUserIdentity uid, CancellationToken ct = default);

        Task<Status> Delete(TId id, TUserIdentity uid, CancellationToken ct = default);
    }
}