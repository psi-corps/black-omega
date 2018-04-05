using System.Threading;
using System.Threading.Tasks;
using PsiCorps.BlackOmega.Results;

namespace PsiCorps.BlackOmega.Interception
{
    public interface ICreationInterceptor<TEntity, TUserIdentity, TOperationContext>
        where TEntity : class
    {
        Task<Result?> InterceptCreation(TEntity entity, TUserIdentity uid, TOperationContext context, CancellationToken ct);
    }
}