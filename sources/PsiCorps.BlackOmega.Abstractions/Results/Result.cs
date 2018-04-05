namespace PsiCorps.BlackOmega.Results
{
    using System;
    using System.Collections.Generic;


    /// <inheritdoc cref="ValueType" />
    /// <summary>
    /// The result.
    /// The status with additional data.
    /// </summary>
    public struct Result : IEquatable<Result>, IEquatable<Status>, IEquatable<long>
    {
        #region Factory methods

        /// <summary>
        /// Creates a new <see cref="Result"/> object with status.
        /// </summary>
        /// <param name="status">The status.</param>
        /// <returns>
        /// The result instance.
        /// </returns>
        public static Result With(Status status) => new Result(status);

        #endregion

        #region State

        private readonly Status _status;
        private IDictionary<object, object> _items;

        #endregion

        #region Constructor

        /// <summary>
        /// Initalizes a new instance of the <see cref="Result"/> type.
        /// </summary>
        /// <param name="status">The status</param>
        public Result(Status status)
        {
            _items = null;
            _status = status;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Adds the additional data to result.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <returns>
        /// Self instance.
        /// </returns>
        public Result WithData(object key, object value)
        {
            (_items ?? (_items = new Dictionary<object, object>()))[key] = value;
            return this;
        }
        
        /// <summary>
        /// Gets the additional data.
        /// </summary>
        public IReadOnlyDictionary<object, object> GetData() => (IReadOnlyDictionary<object, object>) _items;

        #endregion

        #region Object

        public override bool Equals(object obj) => 
            obj is Result result && Equals(result) ||
            obj is Status status && Equals(status) ||
            obj is long value && Equals(value);

        public override int GetHashCode() => _status.GetHashCode();

        public override string ToString() => _status.ToString();

        #endregion

        #region IEquatable

        public bool Equals(Result other) => _status.Equals(other._status);

        public bool Equals(Status other) => _status.Equals(other);

        public bool Equals(long other) => _status.Equals(other);

        #endregion

        #region Operators

        public static bool operator ==(Result left, Result right) => left.Equals(right);

        public static bool operator !=(Result left, Result right) => left.Equals(right);

        public static bool operator ==(Result left, Status right) => left.Equals(right);

        public static bool operator !=(Result left, Status right) => left.Equals(right);

        public static bool operator ==(Status left, Result right) => right.Equals(left);

        public static bool operator !=(Status left, Result right) => right.Equals(left);

        public static bool operator ==(Result left, long right) => left.Equals(right);

        public static bool operator !=(Result left, long right) => left.Equals(right);

        public static bool operator ==(long left, Result right) => left.Equals(right);

        public static bool operator !=(long left, Result right) => left.Equals(right);


        public static implicit operator Status(Result result) => result._status;

        public static implicit operator long(Result result) => result._status;

        public static implicit operator Result(Status status) => new Result(status);

        public static implicit operator Result(long value) => new Result(value);

        #endregion
    }
}