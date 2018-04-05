namespace PsiCorps.BlackOmega.Notification
{
    using System;
    using System.Reflection;


    public interface IOperationNotifier<in TEntity, in TId, in TOperationContext, in TUserIdentity>
    {
  
        void NotifyCreated(TOperationContext context, TEntity entity, TUserIdentity uid);
        void NotifyUpdated(TOperationContext context, TUserIdentity uid, TEntity target, TEntity entity);
        void NotifyDeleted(TOperationContext context, TUserIdentity uid, TEntity target);
        void NotifyFetched(TOperationContext context, TUserIdentity uid, TId id);
    }
}