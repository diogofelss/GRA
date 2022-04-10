using Microsoft.EntityFrameworkCore;
using Textor.GRA.Domain.Entities;
using Textor.GRA.Infra.Data.Mappings;

namespace Textor.GRA.Infra.Data.Context
{
    public class GeneralContext : DbContext
    {
        public GeneralContext(DbContextOptions<GeneralContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MovieMapping());

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieProducer> MovieProducers { get; set; }
        public DbSet<MovieStudio> MovieStudios { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<Studio> Studios { get; set; }
    }
}
