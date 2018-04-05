using System.Reflection;
using PsiCorps.BlackOmega.ServiceLocation;

namespace PsiCorps.BlackOmega.DependencyInjection
{
    using System;


    public abstract class RegistrationFluentSyntax<T>
    {
        protected internal abstract Type GetImplementorType();


        public abstract RegistrationFluentSyntax<T> As(Type serviceType);

        public RegistrationFluentSyntax<T> As<TService>() => As(typeof(TService));

        public RegistrationFluentSyntax<T> AsSelf() => As(typeof(T));

        public RegistrationFluentSyntax<T> AsImplementedInterfaces()
        {
            
        }

        public RegistrationFluentSyntax<T> AsImplementedAbstractClasses()
        {

        }

        
        public RegistrationFluentSyntax<T> AsBaseTypes()
        {

        }


 


        public abstract RegistrationFluentSyntax<T> HandleDispose();

        public abstract RegistrationFluentSyntax<T> DoNotHandleDispose();

        public abstract RegistrationFluentSyntax<T> InstancePerScope();

        public abstract RegistrationFluentSyntax<T> InstancePerDependency();

        public abstract RegistrationFluentSyntax<T> SingleInstance();

        public abstract RegistrationFluentSyntax<T> Named(string name);

        public abstract RegistrationFluentSyntax<T> Keyed(object key);
    }


    public abstract class TypeRegistrationFluentSyntax<T> : RegistrationFluentSyntax<T>
    {
        public abstract TypeRegistrationFluentSyntax<T> WithDependency(Func<ParameterInfo, bool> selector, object instance);

        public abstract TypeRegistrationFluentSyntax<T> WithResolvedDependency<TDependency>(string name = null);
    }
}