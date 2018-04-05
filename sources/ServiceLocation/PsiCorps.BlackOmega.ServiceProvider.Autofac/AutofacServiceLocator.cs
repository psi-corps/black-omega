using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using Autofac;

namespace PsiCorps.BlackOmega.ServiceLocation.Autofac
{
    internal sealed class AutofacServiceLocator : IServiceLocator, IDisposable
    {
        private static readonly ConcurrentDictionary<Type, Type> ResolveAllTypeCache =
            new ConcurrentDictionary<Type, Type>();


        private readonly ILifetimeScope _scope;


        public AutofacServiceLocator(ILifetimeScope scope) => _scope = scope;



        public object Resolve(Type serviceType) => _scope.Resolve(serviceType);

        public object Resolve(Type serviceType, object key) => _scope.ResolveKeyed(key, serviceType);

        public IEnumerable ResolveAll(Type serviceType)
        {
            var type = ResolveAllTypeCache.GetOrAdd(serviceType, _ => typeof(IEnumerable<>).MakeGenericType(serviceType));
            return (IEnumerable) _scope.Resolve(type);
        }


        public IServiceLocator BeginScope() => new AutofacServiceLocator(_scope.BeginLifetimeScope());
        

        public void Dispose() => _scope.Dispose();
    }
}
