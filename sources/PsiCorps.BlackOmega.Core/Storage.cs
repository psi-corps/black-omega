namespace PsiCorps.BlackOmega
{
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using ErrorHandling;
    using IdentityMap;
    using Interception;
    using Notification;
    using Operations;
    using Results;


    public class Storage<TEntity, TId, TUserIdentity, TOperationContext> : IStorage<TEntity, TId, TUserIdentity>
        where TEntity : class
        where TOperationContext : new()
    {
        #region Dependencies

        private readonly IIdentityMap<TEntity, TId> _identityMap;
        private readonly IEntityCreator<TEntity> _creator;
        private readonly IEntityUpdater<TEntity> _updater;
        private readonly IEntityRemover<TEntity> _remover;

        private readonly IInterceptorsProvider<TEntity, TId, TOperationContext, TUserIdentity> _interceptorsProvider;
        private readonly IOperationNotifier<TEntity, TId, TOperationContext, TUserIdentity> _operationNotifier;
        private readonly IStatusProducer _statusProducer;
        private readonly IErrorHandler<TOperationContext, TUserIdentity> _errorHandler;

        #endregion

        #region Constructor

        public Storage(
            IStatusProducer statusProducer,
            IErrorHandler<TOperationContext, TUserIdentity> errorHandler = null,
            IInterceptorsProvider<TEntity, TId, TOperationContext, TUserIdentity> interceptorsProvider = null,
            IOperationNotifier<TEntity, TId, TOperationContext, TUserIdentity> operationNotifer = null,
            IIdentityMap<TEntity, TId> identityMap = null,
            IEntityCreator<TEntity> creator = null,
            IEntityUpdater<TEntity> updater = null,
            IEntityRemover<TEntity> remover = null)
        {
            _statusProducer = statusProducer ?? throw new ArgumentNullException(nameof(statusProducer));
            _errorHandler = errorHandler;
            _interceptorsProvider = interceptorsProvider;
            _operationNotifier = operationNotifer;
            _identityMap = identityMap;
            _creator = creator;
            _updater = updater;
            _remover = remover;
        }

        #endregion

        #region IStorage

        public async Task<Result> Create(TEntity entity, TUserIdentity uid, CancellationToken ct = default)
        {
            if (_creator == null) return _statusProducer.NotSupported();

            var context = new TOperationContext();
            var status = _statusProducer.Created();

            try
            {
                var interceptors = _interceptorsProvider?.GetForCreation() ??
                    Enumerable.Empty<ICreationInterceptor<TEntity, TUserIdentity, TOperationContext>>();

                foreach (var i in interceptors)
                {
                    var maybeResult = await i.InterceptCreation(entity, uid, context, ct);

                    if (!maybeResult.HasValue) continue;

                    status = maybeResult.Value;

                    return status;
                }

                await _creator.CreateEntity(entity, ct);

                return _statusProducer.Created();
            }
            catch (Exception x)
            {
                status = _statusProducer.Error(x);

                if (_errorHandler != null && await _errorHandler.HandleError(x, context, uid, ct))
                    return status;

                throw;
            }
            finally
            {
                if (status == _statusProducer.Created())
                    _operationNotifier?.NotifyCreated(context, entity, uid);
            }
        }

        public async Task<Status> Delete(TId id, TUserIdentity uid, CancellationToken ct = default)
        {
            if (_identityMap == null || _remover == null) return _statusProducer.NotSupported();

            var context = new TOperationContext();
            var status = _statusProducer.Deleted();
            var target = (TEntity) null;

            try
            {
                var interceptors = _interceptorsProvider?.GetForDeletion() ??
                    Enumerable.Empty<IDeletionInterceptor<TId, TUserIdentity, TOperationContext>>();

                foreach (var i in interceptors)
                {
                    var maybeStatus = await i.InterceptDeleteion(id, uid, ct);

                    if (!maybeStatus.HasValue) continue;

                    status = maybeStatus.Value;

                    return maybeStatus.Value;
                }

                target = await _identityMap.GetById(id, ct);

                if (target == null)
                {
                    status = _statusProducer.NotFound();
                }
                else
                {
                    await _remover.RemoveEntity(target, ct);
                }

                return status;
            }
            catch (Exception x)
            {
                status = _statusProducer.Error(x);

                if (_errorHandler != null && await _errorHandler.HandleError(x, context, uid, ct))
                    return status;

                throw;
            }
            finally
            {
                if (status == _statusProducer.Deleted())
                    _operationNotifier?.NotifyDeleted(context, uid, target);
            }
        }

        public async Task<(Status, TEntity)> GetById(TId id, TUserIdentity uid, CancellationToken ct = default)
        {
            if (_identityMap == null) return (_statusProducer.NotSupported(), null);

            var context = new TOperationContext();
            var status = _statusProducer.Ok();

            try
            {
                foreach (var i in _interceptorsProvider.GetForFetching())
                {
                    var maybeStatus = await i.InterceptFetch(context, uid, id, ct);

                    if (!maybeStatus.HasValue) continue;

                    status = maybeStatus.Value;

                    return (status, null);
                }

                var entity = await _identityMap.GetById(id, ct);

                if (entity == null) status = _statusProducer.NotFound();

                return (status, entity);
            }
            catch (Exception x)
            {
                status = _statusProducer.Error(x);

                if (await _errorHandler.HandleError(x, context, uid, ct))
                    return (status, null);

                throw;
            }
            finally
            {
                _operationNotifier.NotifyFetched(context, uid, id);
            }
        }

        public async Task<Result> Update(TId id, TEntity entity, TUserIdentity uid, CancellationToken ct = default)
        {
            if (_identityMap == null || _updater == null) return _statusProducer.NotSupported();

            var context = new TOperationContext();
            var status = _statusProducer.Updated();
            var target = (TEntity) null;

            try
            {
                foreach (var i in _interceptorsProvider.GetForUpdate())
                {
                    var maybeResult = await i.Intercept(context, uid, id, entity);

                    if (!maybeResult.HasValue) continue;

                    status = maybeResult.Value;

                    return maybeResult.Value;
                }

                target = await _identityMap.GetById(id, ct);

                if (target == null)
                {
                    status = _statusProducer.NotFound();
                }
                else
                {
                    await _updater.UpdateEntity(target, entity, ct);
                }

                return status;
            }
            catch (Exception x)
            {
                status = _statusProducer.Error(x);

                if (await _errorHandler.HandleError(x, context, uid, ct))
                    return status;

                throw;
            }
            finally
            {
                if (status == _statusProducer.Updated())
                    _operationNotifier.NotifyUpdated(context, uid, target, entity);
            }
        }

        #endregion
    }
}