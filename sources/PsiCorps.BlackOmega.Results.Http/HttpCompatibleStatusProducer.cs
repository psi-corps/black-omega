namespace PsiCorps.BlackOmega.Results.Http
{
    using System;
    using System.Runtime.CompilerServices;

    using static System.Runtime.CompilerServices.MethodImplOptions;


    /// <inheritdoc />
    /// <summary>
    /// An implementation of <see cref="T:PsiCorps.BlackOmega.Results.IStatusProducer" /> compatible with HTTP status codes.
    /// </summary>
    public sealed class HttpCompatibleStatusProducer : IStatusProducer
    {
        #region Singleton

        /// <summary>
        /// The only instance.
        /// </summary>
        public static readonly IStatusProducer Instance = new HttpCompatibleStatusProducer();

        #endregion

        #region Constructor

        private HttpCompatibleStatusProducer() { }

        #endregion

        #region IStatusProducer

        /// <inheritdoc />
        [MethodImpl(AggressiveInlining)]
        public Status Ok() => 200;

        /// <inheritdoc />
        [MethodImpl(AggressiveInlining)]
        public Status Created() => 204;

        /// <inheritdoc />
        [MethodImpl(AggressiveInlining)]
        public Status Deleted() => 200;

        /// <inheritdoc />
        [MethodImpl(AggressiveInlining)]
        public Status NotSupported() => 405;

        /// <inheritdoc />
        [MethodImpl(AggressiveInlining)]
        public Status NotFound() => 404;

        /// <inheritdoc />
        [MethodImpl(AggressiveInlining)]
        public Status Updated() => 202;

        /// <inheritdoc />
        [MethodImpl(AggressiveInlining)]
        public Status Error(Exception x) => 500;

        #endregion
    }
}

/*
 - IoC Builder;
 - Mvc Integration;
 */