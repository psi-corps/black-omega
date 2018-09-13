namespace BlackOmega.DataAccess
{
    public interface IStorageContextFactory
    {
        IStorageContext CreateContext();
    }
}