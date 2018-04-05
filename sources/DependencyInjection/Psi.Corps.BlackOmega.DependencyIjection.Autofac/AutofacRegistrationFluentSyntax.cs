namespace PsiCorps.BlackOmega.DependencyInjection.Autofac
{
    using System;

    using global::Autofac.Builder;


    internal abstract class AutofacRegistrationFluentSyntax<TTarget, TActivatorData> : RegistrationFluentSyntax
    {
        protected readonly IRegistrationBuilder<TTarget, TActivatorData, SingleRegistrationStyle> Registration;


        protected AutofacRegistrationFluentSyntax(
            IRegistrationBuilder<TTarget, TActivatorData, SingleRegistrationStyle> registration) =>
            Registration = registration;


        public override RegistrationFluentSyntax As(Type serviceType)
        {
            throw new NotImplementedException();
        }

        public override RegistrationFluentSyntax DoNotHandleDispose()
        {
            throw new NotImplementedException();
        }

        public override RegistrationFluentSyntax HandleDispose()
        {
            throw new NotImplementedException();
        }

        public override RegistrationFluentSyntax Keyed(object key)
        {
            throw new NotImplementedException();
        }

        public override RegistrationFluentSyntax Named(string name)
        {
            throw new NotImplementedException();
        }

        public override RegistrationFluentSyntax InstancePerDependency()
        {
            throw new NotImplementedException();
        }

        public override RegistrationFluentSyntax InstancePerScope()
        {
            throw new NotImplementedException();
        }

        public override RegistrationFluentSyntax SingleInstance()
        {
            throw new NotImplementedException();
        }
    }


    internal class AutofacTypeRegistrationFluentSyntax<TTarget>
        : AutofacRegistrationFluentSyntax<TTarget, ConcreteReflectionActivatorData>
    {
        public AutofacTypeRegistrationFluentSyntax(
            IRegistrationBuilder<TTarget, ConcreteReflectionActivatorData, SingleRegistrationStyle>
            registration) : base(registration) { }


        protected override Type GetImplementorType() => Registration.ActivatorData.ImplementationType;
    }


    internal class AutofacInstanceRegistrationFluentSyntax<TTarget>
        : AutofacRegistrationFluentSyntax<TTarget, SimpleActivatorData>
    {
        public AutofacInstanceRegistrationFluentSyntax(
            IRegistrationBuilder<TTarget, SimpleActivatorData, SingleRegistrationStyle>
            registration) : base(registration) { }


        protected override Type GetImplementorType() => Registration.ActivatorData.Activator.LimitType;
    }


    internal class AutofacFactoryRegistrationFluentSyntax<TTarget>
        : AutofacRegistrationFluentSyntax<TTarget, SimpleActivatorData>
    {
        public AutofacFactoryRegistrationFluentSyntax(
            IRegistrationBuilder<TTarget, SimpleActivatorData, SingleRegistrationStyle>
                registration) : base(registration)
        {
        }


        protected override Type GetImplementorType() => Registration.ActivatorData.Activator.LimitType;
    }
}