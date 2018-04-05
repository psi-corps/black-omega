namespace PsiCorps.BlackOmega.Storage
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;


    public interface ISearchQuery<TResult, in TFilter, in TOptions, in TUserIdentity>
    {
        Task<(Status, IReadOnlyCollection<TResult>)> Search(TFilter filter, TOptions options, int skip, int take,
            TUserIdentity userIdentity, CancellationToken ct = default);
    }
}