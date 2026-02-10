// Ethan Wood - Section 2
// AddedMovieContext.cs - Entity Framework DbContext for the movie collection (SQLite)

using Microsoft.EntityFrameworkCore;

namespace Mission6_Wood.Models;

public class AddedMovieContext : DbContext
{
    // Constructor receives connection options from DI (configured in Program.cs)
    public AddedMovieContext(DbContextOptions<AddedMovieContext> options) : base(options)
    {
        
    }
    
    // DbSet represents the Movies table; used to query and add movies
    public DbSet<Movie> Movies { get; set; }
}