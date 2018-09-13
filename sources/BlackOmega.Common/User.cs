namespace BlackOmega
{
    public class User : Entity<string>
    {
        public static User Unathorized { get; set; }
    }
}