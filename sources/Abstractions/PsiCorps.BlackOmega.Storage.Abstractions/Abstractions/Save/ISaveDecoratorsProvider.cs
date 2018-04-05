using System.Collections.Generic;

namespace PsiCorps.BlackOmega.Storage.Abstractions
{
    internal interface ISaveDecoratorsProvider<TInvocationContext>
    {
        ISaveDecorator<TInvocationContext>[] GetDecorators();
    }
}