using System.Collections;
using System.Collections.Generic;
using System.Threading;

namespace PsiCorps.BlackOmega.Interception
{
    public interface IInterceptorsProvider<TEntity, TId, TOperationContext, TUserIdentity>
        where TEntity : class
    {
        IEnumerable<ICreationInterceptor<TEntity, TUserIdentity, TOperationContext>> GetForCreation();
        IEnumerable<IDeletionInterceptor<TId, TUserIdentity, TOperationContext>> GetForDeletion();
        IEnumerable<IUpdateInterceptor<TEntity, TId, TUserIdentity, TOperationContext>> GetForUpdate();
        IEnumerable<IFetchInterceptor<TId, TUserIdentity, TOperationContext>> GetForFetching();
    }
}