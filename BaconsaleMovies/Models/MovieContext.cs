using Microsoft.EntityFrameworkCore;

namespace BaconsaleMovies.Models
{
    public class MovieContext : DbContext
    {
        // Empty constructor for MovieContext Object
        public MovieContext(DbContextOptions<MovieContext> options) : base(options) { }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<CategoryModel> Categories { get; set; }
    }
}
