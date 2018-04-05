namespace PsiCorps.BlackOmega.DependencyInjection.Modularity
{
    using System;


    public static class ModularityFluentSyntax
    {
        public static IServiceRegistry RegisterModule(this IServiceRegistry @this, Module module)
        {
            module.ExportTo(@this);
            return @this;
        }

        public static IServiceRegistry RegisterModule<TModule>(this IServiceRegistry @this) where TModule : Module =>
            @this.RegisterModule(Activator.CreateInstance<TModule>());
    }
}