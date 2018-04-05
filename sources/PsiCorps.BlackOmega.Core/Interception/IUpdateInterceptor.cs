using System.Threading.Tasks;
using PsiCorps.BlackOmega.Results;

namespace PsiCorps.BlackOmega.Interception
{
    public interface IUpdateInterceptor<TEntity, TId, TUserIdentity, TOperationContext> where TEntity : class
    {
        Task<Result?> Intercept(TOperationContext context, TUserIdentity uid, TId id, TEntity entity);
    }
}