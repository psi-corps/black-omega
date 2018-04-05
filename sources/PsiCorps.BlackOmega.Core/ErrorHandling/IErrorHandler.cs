using System;
using System.Threading;
using System.Threading.Tasks;

namespace PsiCorps.BlackOmega.ErrorHandling
{
    public interface IErrorHandler<TOperationContext, TUserIdentity> where TOperationContext : new()
    {
        Task<bool> HandleError(Exception exception, TOperationContext context, TUserIdentity uid, CancellationToken ct);
    }
}