using System.Threading;
using System.Threading.Tasks;
using PsiCorps.BlackOmega.Results;

namespace PsiCorps.BlackOmega.Interception
{
    public interface IDeletionInterceptor<TId, TUserIdentity, TOperationContext>
    {
        Task<Status?> InterceptDeleteion(TId id, TUserIdentity uid, CancellationToken ct);
    }
}