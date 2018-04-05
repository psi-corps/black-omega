using System.Threading;
using System.Threading.Tasks;

namespace PsiCorps.BlackOmega.Operations
{
    public interface IEntityUpdater<T>
    {
        Task UpdateEntity(T source, T entity, CancellationToken ct);
    }
}