namespace PsiCorps.BlackOmega.Storage.Abstractions.GetById
{
    using System.Threading.Tasks;


    public interface IGetByIdNotifier<in TInvocationContext, TEntity, TId, TUserIdentity>
        where TInvocationContext : GetByIdInvocationContext<TEntity, TId, TUserIdentity>
    {
        Task Notify(TInvocationContext context);
    }
}