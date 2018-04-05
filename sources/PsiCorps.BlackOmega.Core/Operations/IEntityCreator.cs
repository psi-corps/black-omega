using System.Threading;
using System.Threading.Tasks;

namespace PsiCorps.BlackOmega.Operations
{
    public interface IEntityCreator<T>
    {
        Task CreateEntity(object entity, CancellationToken ct);
    }
}