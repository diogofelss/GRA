using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Textor.GRA.Domain.Entities;

namespace Textor.GRA.Infra.Data.Mappings
{
    public class MovieStudioMapping : IEntityTypeConfiguration<MovieStudio>
    {
        public void Configure(EntityTypeBuilder<MovieStudio> builder)
        {
            builder.HasKey(c => c.ID);
            builder.HasKey(c => new { c.MovieID, c.StudioID });

            builder.HasOne(c => c.Movie).WithMany(c => c.Studios).HasForeignKey(c => c.MovieID);
            builder.HasOne(c => c.Studio).WithMany(c => c.Movies).HasForeignKey(c => c.StudioID);
        }
    }
}
