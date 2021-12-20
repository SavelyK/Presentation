

namespace PresentationPersistence
{
    public class DbInitializer
    {
        public static void Initialize(PresentationDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
