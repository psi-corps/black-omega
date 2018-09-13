using BlackOmega.Ordering;
using BlackOmega.Ordering.Storage.Orders;

namespace BlackOmega.Contracts.Ordering.Storage
{
    public interface IStorage<TId, TEntity, TUser> :
        IOrderHandler<CreateOrderStatus<TEntity>, TUser, CreateOrder<TEntity, TUser>>
        where TEntity : class
    {

    }
}