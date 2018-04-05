namespace PsiCorps.BlackOmega.Results
{
    using System;
    using System.Runtime.CompilerServices;

    using static System.Runtime.CompilerServices.MethodImplOptions;


    /// <inheritdoc cref="ValueType" />
    /// <summary>
    /// The status object.
    /// </summary>
    public readonly struct Status : IEquatable<Status>, IEquatable<long>
    {
        #region Value

        private readonly long _value;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="Status"/> type.
        /// </summary>
        /// <param name="value">The value.</param>
        [MethodImpl(AggressiveInlining)]
        public Status(long value) => _value = value;

        #endregion

        #region IEquatable

        /// <inheritdoc cref="IEquatable{T}"/>
        [MethodImpl(AggressiveInlining)]
        public bool Equals(Status other) => _value.Equals(other._value);

        /// <inheritdoc cref="IEquatable{T}"/>
        [MethodImpl(AggressiveInlining)]
        public bool Equals(long other) => other == _value;

        #endregion

        #region Object

        /// <inheritdoc cref="object"/>
        [MethodImpl(AggressiveInlining)]
        public override bool Equals(object obj) =>
            obj is Status status && Equals(status) || obj is long value && Equals(value);

        /// <inheritdoc cref="object"/>
        [MethodImpl(AggressiveInlining)]
        public override int GetHashCode() => _value.GetHashCode();

        /// <inheritdoc cref="object"/>
        [MethodImpl(AggressiveInlining)]
        public override string ToString() => _value.ToString();

        #endregion

        #region Methods

        /// <summary>
        /// Converts the status to the <see cref="Result"/> object.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        [MethodImpl(AggressiveInlining)]
        public Result WithData(object key, object value) => new Result(this).WithData(key, value);

        #endregion

        #region Operators

        /// <summary>
        /// Converts an instance of the <see cref="Status"/> object to the <langword cref="long"/> value.
        /// </summary>
        /// <param name="status">The status.</param>
        public static implicit operator long(Status status) => status._value;

        /// <summary>
        /// Converts the <langword cref="long"/> value to instance of the <see cref="Status"/> object.
        /// </summary>
        /// <param name="value">The value.</param>
        public static implicit operator Status(long value) => new Status(value);

        #endregion
    }
}