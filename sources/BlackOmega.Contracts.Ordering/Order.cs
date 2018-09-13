namespace BlackOmega.Ordering
{
    public abstract class Order<TUser> : IOrder<TUser>
    {
        protected Order(string source, TUser caller)
        {
            Source = source;
            Caller = caller;
        }
        
        
        public string Source { get; }

        
        public TUser Caller { get; }
    }
}