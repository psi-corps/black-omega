using Microsoft.Extensions.DependencyInjection;
using PsiCorps.BlackOmega.ServiceLocation;
using PsiCorps.BlackOmega.Storage.DependencyInjection;

namespace PsiCorps.BlackOmega.Storage
{
    public class StorageProvider
    {
        private StoragesConfiguration configuration;
        private IServiceCollection @this;

        public StorageProvider(StoragesConfiguration configuration, IServiceLocator serviceLocator)
        {
            this.configuration = configuration;
            this.@this = @this;
        }
    }
}