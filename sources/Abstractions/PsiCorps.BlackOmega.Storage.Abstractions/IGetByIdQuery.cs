namespace PsiCorps.BlackOmega.Storage
{
    using System.Threading;
    using System.Threading.Tasks;


    public interface IGetByIdQuery<TEntity, in TId, in TUserIdentity>
    {
        Task<(Status, TEntity)> GetById(TId id, TUserIdentity userIdentity, CancellationToken ct = default);
    }
}
