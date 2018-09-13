using System;
using System.Threading.Tasks;

namespace BlackOmega.ExceptionHandling
{
    public interface IExceptionHandler
    {
        ValueTask<bool> HandleException(Exception x);
    }
}