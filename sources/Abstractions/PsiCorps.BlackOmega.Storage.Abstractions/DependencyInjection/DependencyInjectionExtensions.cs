using System;
using System.ComponentModel.Design;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using PsiCorps.BlackOmega.DependencyInjection;
using PsiCorps.BlackOmega.ServiceLocation;

namespace PsiCorps.BlackOmega.Storage.DependencyInjection
{
    public static class DependencyInjectionExtensions
    {
        public static ServiceRegistry RegisterStorages<TUserIdentity>(this ServiceRegistry @this,
            Action<StoragesConfiguration<TUserIdentity>> configure)
        {
            var config = new StoragesConfiguration<TUserIdentity>();

            configure(config);

            @this.RegisterTypes(new ServiceDiscoverer(config.Assemblies, config.Conventions));

            @this.RegisterType<StorageProvider>()
                .WithResolvedDependency<IServiceLocator>()
                .AsSelf()
                .SingleInstance();
            
            return @this;
        }
    }
}