using System.Threading;
using System.Threading.Tasks;

namespace PsiCorps.BlackOmega.Operations
{
    public interface IEntityRemover<T>
    {
        Task RemoveEntity(object target, CancellationToken ct);
    }
}