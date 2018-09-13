namespace BlackOmega.Ordering
{
    using System.Threading;
    using System.Threading.Tasks;


    public interface IOrderHandler<TStatus, TUser, in TOrder> where TOrder : IOrder<TUser>
    {
        Task<TStatus> ExecuteCommand(TOrder order, CancellationToken ct = default);
    } 
}