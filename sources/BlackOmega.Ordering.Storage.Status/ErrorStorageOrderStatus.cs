using System;

namespace BlackOmega.Ordering.Storage
{
    public class ErrorSaveOrderStatus : StorageOrderStatus
    {
        public ErrorSaveOrderStatus(Exception x) => Exception = x;
        
        
        public Exception Exception { get; }
    }
}