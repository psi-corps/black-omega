using System;
using PsiCorps.BlackOmega.DependencyInjection;

namespace PsiCorps.BlackOmega.Storage.DependencyInjection.Builders
{
    internal class StorageBuilderDiscoverer<TEntity> : IServiceDiscoverer
    {
        private readonly StorageBuilder<TEntity> _builder;


        public StorageBuilderDiscoverer(StorageBuilder<TEntity> builder) => _builder = builder;


        public Type[] DiscoverServices()
        {
            throw new NotImplementedException();
        }
    }
}