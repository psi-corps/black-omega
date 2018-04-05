namespace PsiCorps.BlackOmega.ServiceLocation
{
    using System;
    using System.Collections;


    public interface IServiceLocator
    {
        object Resolve(Type serviceType);

        object Resolve(Type serviceType, object key);

        IEnumerable ResolveAll(Type serviceType);


        IServiceLocator BeginScope();
    }
}
