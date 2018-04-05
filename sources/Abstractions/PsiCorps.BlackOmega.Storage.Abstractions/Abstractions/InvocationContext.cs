using System;
using System.Collections.Generic;
using System.Text;

namespace PsiCorps.BlackOmega.Storage
{
    public class InvocationContext<TUserIdentity>
    {
        public TUserIdentity UserIdentity { get; set; }

        public Exception Error { get; set; }
    }
}
