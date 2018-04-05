using System.Threading;
using System.Threading.Tasks;
using PsiCorps.BlackOmega.Results;

namespace PsiCorps.BlackOmega.Interception
{
    public interface IFetchInterceptor<TId, TUserIdentity, TOperationContext>
    {
        Task<Status?> InterceptFetch(TOperationContext context, TUserIdentity uid, TId id,
            CancellationToken ct = default);
    }
}