using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Textor.GRA.Domain.Entities;

namespace Textor.GRA.Infra.Data.Mappings
{
    public class MovieProducerMapping : IEntityTypeConfiguration<MovieProducer>
    {
        public void Configure(EntityTypeBuilder<MovieProducer> builder)
        {
            builder.HasKey(c => c.ID);
            builder.HasKey(c => new { c.MovieID, c.ProducerID });

            builder.HasOne(c => c.Movie).WithMany(c => c.Producers).HasForeignKey(c => c.MovieID);
            builder.HasOne(c => c.Producer).WithMany(c => c.Movies).HasForeignKey(c => c.ProducerID);
        }
    }
}
