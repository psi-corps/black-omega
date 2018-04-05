namespace PsiCorps.BlackOmega.Storage
{
    using System.Threading;
    using System.Threading.Tasks;


    public interface ISaveCommand<in TEntity, in TUserIdentity>
    {
        Task<Status> Save(TEntity entity, TUserIdentity userIdentity, CancellationToken ct);
    }
}