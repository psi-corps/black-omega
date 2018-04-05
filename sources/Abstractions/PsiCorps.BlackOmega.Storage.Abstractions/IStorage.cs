namespace PsiCorps.BlackOmega.Storage
{
    public interface IStorage<TEntity, in TId, in TUserIdentity> : IGetByIdQuery<TEntity, TId, TUserIdentity>,
        ISaveCommand<TEntity, TUserIdentity>, IUpdateCommand<TEntity, TId, TUserIdentity>,
        IRemoveCommand<TId, TUserIdentity> { }
}