namespace PsiCorps.BlackOmega.DependencyInjection.Autofac
{
    using System;

    using global::Autofac;

    using ServiceLocation;


    public class AutofacServiceRegistry : ServiceRegistry
    {
        private readonly ContainerBuilder _containerBuilder;


        public AutofacServiceRegistry(ContainerBuilder containerBuiler = null) =>
            _containerBuilder = containerBuiler ?? new ContainerBuilder();


        public ServiceRegistry RegisterType(Type serviceType, Action<RegistrationFluentSyntax> syntax)
        {
            var reg = _containerBuilder.RegisterType(serviceType);
            var stx = new AutofacTypeRegistrationFluentSyntax<object>(reg);

            (syntax ?? throw new ArgumentNullException(nameof(syntax))).Invoke(stx);

            return this;
        }

        public IServiceRegistry RegisterType<T>(Action<RegistrationFluentSyntax> syntax) => RegisterType(typeof(T), syntax);

        public IServiceRegistry RegisterInstance<T>(T instance, Action<RegistrationFluentSyntax> syntax)
            where T : class
        {
            var reg = _containerBuilder.RegisterInstance(instance);
            var stx = new AutofacInstanceRegistrationFluentSyntax<T>(reg);

            (syntax ?? throw new ArgumentNullException(nameof(syntax))).Invoke(stx);

            return this;
        }

        public IServiceRegistry RegisterFactory<T>(Func<IServiceLocator, T> factory, Action<RegistrationFluentSyntax> syntax)
        {
            var reg = _containerBuilder.Register(ctx => factory(ctx.Resolve<IServiceLocator>()));
            var stx = new AutofacFactoryRegistrationFluentSyntax<T>(reg);

            (syntax ?? throw new ArgumentNullException(nameof(syntax))).Invoke(stx);

            return this;
        }

        public IServiceLocator CreateServiceLocator() => new AutofacServiceLocator(_containerBuilder.Build());
    }
}

