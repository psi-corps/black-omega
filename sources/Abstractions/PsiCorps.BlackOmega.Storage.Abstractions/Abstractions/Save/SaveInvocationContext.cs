namespace PsiCorps.BlackOmega.Storage.Abstractions.Save
{
    public class SaveInvocationContext<TEntity, TUserIdentity> : InvocationContext<TUserIdentity>
    {
        public TEntity Entity { get; set; }

        public Status? Status { get; set; }
    }
}