using BlackOmega.Ordering;

namespace BlackOmega.Aurora
{
    public class AuroraMissle<TOrder, TInitiator> where TOrder : Order
    {
        public TOrder Order { get; }
        
        public TInitiator Initiator { get; }
    }
}