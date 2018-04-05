using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PsiCorps.BlackOmega.Storage
{
    public class Storage<TEntity, TId, TUserIdentity, TInvocationContext>
        where TInvocationContext : class, new()
    {
        private readonly dynamic _identityMap;
        private readonly dynamic _decoratorsResolver;


        public Storage(dynamic identityMap)
        {

        }


        public async Task<(Status, TEntity)> GetById(TId id, TUserIdentity userIdentity, CancellationToken ct = default)
        {
            var invocationContext = new TInvocationContext();

            try
            {
                var decorators = _decoratorsResolver.ResolveGetByIdDecorators();

                foreach (var decorator in decorators)
                {
                    var result = await decorator.BeforeQuery(invocationContext, userIdentity, id);
                    if (result.HasValue) return result.Value;
                }


            }
            catch (Exception x)
            {
                
            }
        }
    }
}
