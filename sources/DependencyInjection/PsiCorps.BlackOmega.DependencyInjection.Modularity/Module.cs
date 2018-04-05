using System;

namespace PsiCorps.BlackOmega.DependencyInjection.Modularity
{
    public abstract class Module
    {
        public abstract void ExportTo(IServiceRegistry serviceRegistry);
    }
}
