namespace PsiCorps.BlackOmega
{
    using System.Collections.Generic;


    public class StatusComparer : IEqualityComparer<Status>, IComparer<Status>
    {
        public static readonly StatusComparer Instance = new StatusComparer();


        public bool Equals(Status x, Status y) => x.Equals(y);

        public int GetHashCode(Status obj) => obj.GetHashCode();

        public int Compare(Status x, Status y) => ((long) x).CompareTo(y);
    }
}