using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PresentationDomain;

namespace PresentationPersistence.EntityTypeConfiguration
{
    public class PresentationConfiguration : IEntityTypeConfiguration<Presentation>
    {
        public void Configure(EntityTypeBuilder<Presentation> builder)
        {
            builder.HasKey(presentation => presentation.EventId);
        }
    }
}
