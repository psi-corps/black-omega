namespace PsiCorps.BlackOmega
{
    using System;
    using System.Runtime.CompilerServices;

    using static System.Runtime.CompilerServices.MethodImplOptions;


    public readonly struct Status : IEquatable<Status>, IEquatable<long>
    {
        private readonly long _status;


        [MethodImpl(AggressiveInlining)]
        public Status(long status) => _status = status;


        [MethodImpl(AggressiveInlining)]
        public override bool Equals(object obj) => obj is Status s && Equals(s) || obj is long l && Equals(l);

        [MethodImpl(AggressiveInlining)]
        public override int GetHashCode() => _status.GetHashCode();

        [MethodImpl(AggressiveInlining)]
        public override string ToString() => _status.ToString();


        [MethodImpl(AggressiveInlining)]
        public bool Equals(Status status) => Equals(status._status);

        [MethodImpl(AggressiveInlining)]
        public bool Equals(long status) => _status == status;


        [MethodImpl(AggressiveInlining)]
        public static implicit operator long(Status status) => status._status;

        [MethodImpl(AggressiveInlining)]
        public static implicit operator Status(long status) => new Status(status);


        [MethodImpl(AggressiveInlining)]
        public static bool operator ==(Status left, Status right) => left.Equals(right);

        [MethodImpl(AggressiveInlining)]
        public static bool operator !=(Status left, Status right) => !left.Equals(right);

        [MethodImpl(AggressiveInlining)]
        public static bool operator ==(Status left, long right) => left.Equals(right);

        [MethodImpl(AggressiveInlining)]
        public static bool operator !=(Status left, long right) => !left.Equals(right);

        [MethodImpl(AggressiveInlining)]
        public static bool operator ==(long left, Status right) => right.Equals(right);

        [MethodImpl(AggressiveInlining)]
        public static bool operator !=(long left, Status right) => !right.Equals(right);
    }
}
