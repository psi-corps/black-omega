namespace PsiCorps.BlackOmega.DependencyInjection
{
    using System;
    using System.Reflection;

    using ServiceLocation;

    public abstract class ServiceRegistry
    {
        #region Properties

        public Assembly ThisAssembly => Assembly.GetCallingAssembly();

        #endregion

        #region Abstracts

        public abstract RegistrationFluentSyntax<object> RegisterTypes(params ServiceDiscoverer[] discoverers);

        public abstract TypeRegistrationFluentSyntax<object> RegisterType(Type serviceType);

        public abstract TypeRegistrationFluentSyntax<T> RegisterType<T>();

        public abstract RegistrationFluentSyntax<T> RegisterInstance<T>(T instance, Action<RegistrationFluentSyntax<T>> syntax) where T : class;

        public abstract RegistrationFluentSyntax<T> RegisterFactory<T>(Func<IServiceLocator, T> factory,
            Action<RegistrationFluentSyntax<T>> syntax);

        public abstract IServiceLocator CreateServiceLocator();

        #endregion
    }
}