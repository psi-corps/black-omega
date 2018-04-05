namespace PsiCorps.BlackOmega.Storage.Abstractions
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    using Save;


    public class SaveCommandBase<TEntity, TUserIdentity, TInvocationContext> : ISaveCommand<TEntity, TUserIdentity>
        where TInvocationContext : SaveInvocationContext<TEntity, TUserIdentity>, new()
    {
        private readonly ISaveDecoratorsProvider<TInvocationContext> _decoratorsProvider;
        private readonly IEntitySaver<TEntity> _saver;
        private readonly ISaveNotifier<TEntity> _notifier;
        private readonly ISaveStatusProvider _statusProvider;


        public SaveCommandBase(ISaveDecoratorsProvider<TInvocationContext> decoratorsProvider,
            IEntitySaver<TEntity> saver, ISaveNotifier<TEntity> notifier, ISaveStatusProvider statusProvider)
        {
            _decoratorsProvider = decoratorsProvider ?? throw new ArgumentNullException(nameof(decoratorsProvider));
            _saver = saver ?? throw new ArgumentNullException(nameof(saver));
            _notifier = notifier ?? throw new ArgumentNullException(nameof(notifier));
            _statusProvider = statusProvider ?? throw new ArgumentNullException(nameof(statusProvider));
        }


        #region MyRegion


        public async Task<Status> Save(TEntity entity, TUserIdentity userIdentity, CancellationToken ct)
        {
            var context = new TInvocationContext {Entity = entity, UserIdentity = userIdentity};

            try
            {
                var decorators = _decoratorsProvider.GetDecorators();

                foreach (var decorator in decorators)
                {
                    await decorator.BeforeCommand(context, ct);
                    if (context.Status.HasValue) return context.Status.Value;
                }

                await _saver.SaveEntity(entity, ct);

                context.Status = _statusProvider.Saved();

                foreach (var decorator in decorators)
                {
                    await decorator.AfterCommand(context, ct);
                }

                return context.Status.Value;
            }
            catch (Exception x)
            {
                context.Error = x;
                return _statusProvider.Error(x);
            }
            finally
            {
                await _notifier.NotifySave(context);
            }
        }

        #endregion
    }

    internal interface ISaveNotifier<TInvocationContext>
    {
        Task NotifySave(T context);
    }

    internal interface IEntitySaver<T>
    {
    }

    internal interface ISaveStatusProvider
    {
        Status Saved();
        Status Error(Exception exception);
    }
}