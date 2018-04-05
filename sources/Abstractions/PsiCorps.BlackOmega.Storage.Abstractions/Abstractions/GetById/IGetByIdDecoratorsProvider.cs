namespace PsiCorps.BlackOmega.Storage.Abstractions.GetById
{
    public interface IGetByIdDecoratorsProvider<in TInvocationContext, TEntity, TId, TUserIdentity>
        where TInvocationContext : GetByIdInvocationContext<TEntity, TId, TUserIdentity>
    {
        IGetByIdDecorator<TInvocationContext, TEntity, TId, TUserIdentity>[] GetDecorators();
    }
}