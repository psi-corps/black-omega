using System;
using System.Collections.Generic;
using System.Reflection;
using System.Timers;
using PsiCorps.BlackOmega.DependencyInjection;
using PsiCorps.BlackOmega.Storage.Abstractions.GetById;
using PsiCorps.BlackOmega.Storage.DependencyInjection.Builders;
using PsiCorps.BlackOmega.Storage.DependencyInjection.Conventions;
using PsiCorps.BlackOmega.Storage.DependencyInjection.Discovering.Conventional;

namespace PsiCorps.BlackOmega.Storage.DependencyInjection
{
    public class StorageDecoratorsCollection<TEntity, TId, TUserIDentity>
    {
        private readonly IList<Type> _getByIdDecorators;
        private readonly Type[] _saveDecorators;
        private readonly Type[] _updateDecorators;
        private readonly Type[] _removeDecoratos;


        public StorageDecoratorsCollection<TEntity, TId, TUserIDentity> DecorateGetById(
            IServiceDiscoverer discoverer)
        {
            foreach (var service in discoverer.DiscoverServices())
            {
                _getByIdDecorators.Add(service);
            }

            return this;
        }

    }


    public class StoragesConfiguration<TUserIdentity>
    {
        private readonly ServiceRegistry _serviceRegistry;


        internal StoragesConfiguration(ServiceRegistry serviceRegistry) =>
            _serviceRegistry = serviceRegistry;


        public StoragesConfiguration<TUserIdentity> DiscoverStorages(Action<ServiceDiscoverer.Configuration> configure)
        {
            var config = new ServiceDiscoverer.Configuration();

            configure(config);

            _serviceRegistry
                .RegisterTypes(new ServiceDiscoverer(config))
                .SingleInstance()
                .AsBaseTypes()
                .AsSelf();
            
            return this;
        }

        public StoragesConfiguration<TUserIdentity> ConfigureGlobalDecorators<TEntity, TId, TUserIdentity>(
            Action<StorageDecoratorsCollection<TEntity, TId, TUserIdentity>> configure)
        {
            
        }

        public StoragesConfiguration<TUserIdentity> UseStorage<TEntity, TId>(
            Action<StorageBuilder<TEntity, TId, TUserIdentity>> build)
        {
            var builder = new StorageBuilder<TEntity, TId, TUserIdentity>();

            (build ?? throw new ArgumentNullException(nameof(build))).Invoke(builder);

            return this;
        }
    }
}