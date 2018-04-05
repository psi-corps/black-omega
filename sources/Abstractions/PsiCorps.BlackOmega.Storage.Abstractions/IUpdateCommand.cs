namespace PsiCorps.BlackOmega.Storage
{
    using System.Threading;
    using System.Threading.Tasks;


    public interface IUpdateCommand<in TEntity, in TId, in TUserIdentity>
    {
        Task<Status> Update(TId id, TEntity entity, TUserIdentity userIdentity, CancellationToken ct = default);
    }
}