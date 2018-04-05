namespace PsiCorps.BlackOmega.Storage.Abstractions.GetById
{
    public class GetByIdInvocationContext<TEntity, TId, TUserIdentity> : InvocationContext<TUserIdentity>
    {
        public TId Id { get; set; }

        public (Status, TEntity)? Result { get; set; }
    }
}