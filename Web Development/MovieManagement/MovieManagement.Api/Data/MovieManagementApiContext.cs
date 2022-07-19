using Microsoft.EntityFrameworkCore;
using MovieManagement.Api.Models;

namespace MovieManagement.Api.Data
{
    public class MovieManagementApiContext : DbContext
    {
        private readonly IConfiguration configuration;

        public MovieManagementApiContext (DbContextOptions<MovieManagementApiContext> options, 
            IConfiguration configuration)
            : base(options)
        {
            this.configuration = configuration;
        }

        public DbSet<Movie>? Movie { get; set; }
        public DbSet<Genre>? Genres { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(configuration.GetConnectionString("MovieManagementApiContext") 
                ?? throw new InvalidOperationException("Connection string 'MovieManagementApiContext' not found."));
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>()
                .HasOne(x => x.Genre);
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
