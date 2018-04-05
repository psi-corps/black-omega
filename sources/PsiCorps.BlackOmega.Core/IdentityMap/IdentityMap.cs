using System;
using System.Threading;
using System.Threading.Tasks;

namespace PsiCorps.BlackOmega.IdentityMap
{
    public class IdentityMap<TEntity, TId, TOptions> : IIdentityMap<TEntity, TId>, IDisposable
        where TOptions : IdentityMapOptions
    {
        private readonly TOptions _options;

        private readonly IIdentityMapEngine<TEntity, TId> _engine;
        private readonly IInvalidationListener<TId> _invalidationListener;
        private readonly IUpdateListener<TEntity, TId> _updateListener;
        private readonly IIdentityMap<TEntity, TId> _fallbackMap;


        public IdentityMap(
            TOptions options,
            IIdentityMapEngine<TEntity, TId> engine,
            IInvalidationListener<TId> invalidationListener = null,
            IUpdateListener<TEntity, TId> updateListener = null,
            IIdentityMap<TEntity, TId> fallbackMap = null)
        {
            _options = options ?? throw new ArgumentNullException(nameof(options));
            _engine = engine ?? throw new ArgumentNullException(nameof(engine));
            _invalidationListener = invalidationListener;
            _updateListener = updateListener;
            _fallbackMap = fallbackMap;

            if (_invalidationListener != null)
                _invalidationListener.Invalidate += _engine.Invalidate;
            if (_updateListener != null)
                _updateListener.Update += _engine.Update;
        }


        public async Task<TEntity> GetById(TId id, CancellationToken ct)
        {
            var result = await _engine.GetById(id, ct);

            if (result != null) return result;

            result = await _fallbackMap.GetById(id, ct);

            if (result != null && !_options.ForgetFallbackResults)
                await _engine.Update(id, result, ct);

            return result;
        }

        public void Dispose()
        {
            _invalidationListener.Invalidate -= _engine.Invalidate;
            _updateListener.Update -= _engine.Update;
        }
    }

    public interface IUpdateListener<TEntity, TId>
    {
        event Func<TId, TEntity, CancellationToken, Task> Update;
    }

    public interface IInvalidationListener<TId>
    {
        event Func<TId, CancellationToken, Task> Invalidate;
    }
}