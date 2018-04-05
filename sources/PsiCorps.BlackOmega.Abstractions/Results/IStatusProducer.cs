namespace PsiCorps.BlackOmega.Results
{
    using System;


    /// <summary>
    /// An interface to the status producer.
    /// </summary>
    public interface IStatusProducer
    {
        /// <summary>
        /// Creates the "OK" status.
        /// </summary>
        Status Ok();

        /// <summary>
        /// Creates the "Error" status.
        /// </summary>
        Status Error(Exception x);

        Status Created();
        Status Deleted();
        Status NotSupported();
        Status NotFound();
        Status Updated();
    }
}