using System.Threading.Tasks;

namespace BlackOmega.Ordering.Storage.Notifications
{
    public interface IStorageNotifier<TInitiator>
    {
        Task NotifyEntitySaved<TEntity>(EntitySavedNotification<TInitiator, TEntity> notification);
    }
}