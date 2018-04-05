using System.Threading;
using System.Threading.Tasks;
using PsiCorps.BlackOmega.Storage.Abstractions.Save;

namespace PsiCorps.BlackOmega.Storage.Abstractions
{
    public interface ISaveDecorator<TInvocationContext>
    {
        Task BeforeCommand(TInvocationContext context, CancellationToken ct);
        Task AfterCommand(TInvocationContext context, CancellationToken ct);
    }
}