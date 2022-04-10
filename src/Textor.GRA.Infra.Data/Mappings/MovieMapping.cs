using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Textor.GRA.Domain.Entities;

namespace Textor.GRA.Infra.Data.Mappings
{
    public class MovieMapping : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.HasKey(c => c.ID);

            builder.Property(c => c.Title).HasMaxLength(200);
            builder.Property(c => c.Year);
            builder.Property(c => c.Winner);

            builder.HasMany(c => c.Producers).WithOne(c => c.Movie).HasForeignKey(c => c.MovieID);
            builder.HasMany(c => c.Studios).WithOne(c => c.Movie).HasForeignKey(c => c.MovieID);
        }
    }
}
