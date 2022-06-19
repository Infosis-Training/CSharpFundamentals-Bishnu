using Microsoft.EntityFrameworkCore;
using MovieManagement.Models;

namespace MovieManagement.Data
{
    public class MovieManagementDb : DbContext
    {
        public MovieManagementDb(DbContextOptions<MovieManagementDb> options) 
            : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }

        public DbSet<MovieManagement.Models.Genre>? Genre { get; set; }
    }
}
