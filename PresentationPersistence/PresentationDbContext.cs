using Microsoft.EntityFrameworkCore;
using PresentationApplication.Interfaces;
using PresentationDomain;
using PresentationPersistence.EntityTypeConfiguration;


namespace PresentationPersistence
{
    public class PresentationDbContext : DbContext, IPresentationDbContext
    {
        public DbSet<Presentation> Presentaions { get; set; }
        
        public PresentationDbContext(DbContextOptions<PresentationDbContext> options)
            : base(options) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new PresentationConfiguration());
            base.OnModelCreating(builder);
        }
    }
}
