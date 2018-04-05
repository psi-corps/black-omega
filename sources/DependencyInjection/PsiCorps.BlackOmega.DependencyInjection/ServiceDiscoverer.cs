namespace PsiCorps.BlackOmega.DependencyInjection
{
    using System;
    using System.Reflection;
    using System.Collections.Generic;
    using System.Linq;


    public class ServiceDiscoverer
    {
        private readonly IEnumerable<Assembly> _assemblies;
        private readonly IEnumerable<Func<Type, bool>> _conventions;


        public ServiceDiscoverer(Configuration configuration)
        {
            _assemblies = configuration?.Assemblies ??
                throw new ArgumentNullException(nameof(Configuration.Assemblies));
            _conventions = configuration.Conventions ??
                throw new ArgumentNullException(nameof(Configuration.Conventions));
        }


        public Type[] DiscoverServices() => _assemblies
            .SelectMany(a => a.ExportedTypes)
            .Where(t => _conventions.All(c => c(t)))
            .ToArray();

        
        public class Configuration
        {
            private readonly ISet<Assembly> _assemblies = new HashSet<Assembly>();
            private readonly ISet<Func<Type, bool>> _conventions = new HashSet<Func<Type, bool>>();


            public Configuration AddAssemblies(params Assembly[] assemblies)
            {
                assemblies.Select(_assemblies.Add);
                return this;
            }

            public Configuration AddConventions(params Func<Type, bool>[] conventions)
            {
                conventions.Select(_conventions.Add);
                return this;
            }


            public IEnumerable<Assembly> Assemblies => _assemblies;

            public IEnumerable<Func<Type, bool>> Conventions => _conventions;
        }
    }
}