namespace PsiCorps.BlackOmega.Storage.Abstractions.GetById
{
    using System.Threading;
    using System.Threading.Tasks;


    public interface IIdentityMap<in TId, TEntity>
    {
        Task<TEntity> GetById(TId id, CancellationToken ct);
    }
}