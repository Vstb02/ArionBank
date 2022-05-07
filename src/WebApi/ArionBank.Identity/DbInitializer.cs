using ArionBank.Account.Data;

namespace ArionBank.Identity
{
    public class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
