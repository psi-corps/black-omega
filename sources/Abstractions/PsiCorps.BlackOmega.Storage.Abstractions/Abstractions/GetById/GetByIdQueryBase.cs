namespace PsiCorps.BlackOmega.Storage.Abstractions.GetById
{
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;


    public class GetByIdQueryBase<TEntity, TId, TUserIdentity, TInvocationContext> : IGetByIdQuery<TEntity, TId, TUserIdentity>
        where TInvocationContext : GetByIdInvocationContext<TEntity, TId, TUserIdentity>, new()
    {
        #region Dependencies

        private readonly IGetByIdDecoratorsProvider<TInvocationContext, TEntity, TId, TUserIdentity>
            _decoratorsProvider;

        private readonly IIdentityMap<TId, TEntity> _identityMap;
        private readonly IGetByIdStatusProvider _statusProvider;
        private readonly IGetByIdNotifier<TInvocationContext, TEntity, TId, TUserIdentity> _notifier;

        #endregion

        #region Constructor

        public GetByIdQueryBase(
            IGetByIdDecoratorsProvider<TInvocationContext, TEntity, TId, TUserIdentity> decoratorProvider,
            IIdentityMap<TId, TEntity> identityMap, IGetByIdStatusProvider statusProvider,
            IGetByIdNotifier<TInvocationContext, TEntity, TId, TUserIdentity> notifier)
        {
            _decoratorsProvider = decoratorProvider ?? throw new ArgumentNullException(nameof(decoratorProvider));
            _identityMap = identityMap ?? throw new ArgumentNullException(nameof(identityMap));
            _statusProvider = statusProvider ?? throw new ArgumentNullException(nameof(statusProvider));
            _notifier = notifier ?? throw new ArgumentNullException(nameof(notifier));

        }

        #endregion

        #region IGetByIdQuery

        public async Task<(Status, TEntity)> GetById(TId id, TUserIdentity userIdentity, CancellationToken ct = default)
        {
            var context = new TInvocationContext {Id = id, UserIdentity = userIdentity};

            try
            {
                var decorators = _decoratorsProvider.GetDecorators();

                foreach (var decorator in decorators)
                {
                    await decorator.BeforeQuery(context, ct);
                    if (context.Result.HasValue) return context.Result.Value;
                }

                var entity = await _identityMap.GetById(id, ct);
                var status = entity == null ? _statusProvider.NotFound() : _statusProvider.Ok();

                context.Result = (status, entity);
                
                foreach (var decorator in decorators.Reverse())
                {
                    await decorator.AfterQuery(context, ct);
                }

                return context.Result.Value;
            }
            catch (Exception x)
            {
                context.Error = x;
                return (_statusProvider.Error(x), default);
            }
            finally
            {
                await _notifier.Notify(context);
            }
        }

        #endregion
    }
}