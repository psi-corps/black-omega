namespace PsiCorps.BlackOmega.Storage.Abstractions.GetById
{
    using System.Threading;
    using System.Threading.Tasks;


    public interface IGetByIdDecorator<in TInvocationContext, TEntity, TId, TUserIdentity>
        where TInvocationContext : GetByIdInvocationContext<TEntity, TId, TUserIdentity>
    {
        Task BeforeQuery(TInvocationContext context, CancellationToken ct);

        Task AfterQuery(TInvocationContext context, CancellationToken ct);
    }
}