using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Textor.GRA.Domain.Entities;

namespace Textor.GRA.Infra.Data.Mappings
{
    public class StudioMapping : IEntityTypeConfiguration<Studio>
    {
        public void Configure(EntityTypeBuilder<Studio> builder)
        {
            builder.HasKey(c => c.ID);

            builder.Property(c => c.Name);

            builder.HasMany(c => c.Movies).WithOne(c => c.Studio).HasForeignKey(c => c.StudioID);
        }
    }
}
