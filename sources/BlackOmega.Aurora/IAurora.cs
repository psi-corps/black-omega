using System.Threading;
using System.Threading.Tasks;
using BlackOmega.Ordering;

namespace BlackOmega.Aurora
{
    public interface IAurora<TInitiator>
    {
        Task LaunchMissle<TOrder>(AuroraMissle<TOrder, TInitiator> missle, CancellationToken ct = default) where TOrder : Order;
    }
}