namespace PsiCorps.BlackOmega.Storage
{
    public class SearchQuery<TFilter, TOptions>
    {
        public TFilter Filter { get; set; }

        public TOptions Options { get; set; }

        public int Skip { get; set; }

        public int Take { get; set; }
    }
}