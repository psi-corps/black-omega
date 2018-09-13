namespace BlackOmega.Ordering
{
    public interface IOrder<out TUser>
    {
        string Source { get; }
        
        TUser Caller { get; }
    }
}