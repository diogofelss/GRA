using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Textor.GRA.Domain.Entities;

namespace Textor.GRA.Infra.Data.Mappings
{
    public class ProducerMapping : IEntityTypeConfiguration<Producer>
    {
        public void Configure(EntityTypeBuilder<Producer> builder)
        {
            builder.HasKey(c => c.ID);

            builder.Property(c => c.Name).HasMaxLength(500);

            builder.HasMany(c => c.Movies).WithOne(c => c.Producer).HasForeignKey(c => c.ProducerID);
        }
    }
}
