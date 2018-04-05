namespace PsiCorps.BlackOmega.Storage
{
    using System.Threading;
    using System.Threading.Tasks;


    public interface IRemoveCommand<in TId, in TUserIdentity>
    {
        Task<Status> Remove(TId id, TUserIdentity userIdentity, CancellationToken ct = default);
    }
}