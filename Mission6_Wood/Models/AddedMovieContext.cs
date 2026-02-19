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
    
    // DbSet represents the Categories table; used for dropdowns and movie category lookup
    public DbSet<Category> Categories { get; set; }

    // Seed the Categories table with initial category options (runs on first migration)
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>().HasData(
            
            new Category {CategoryID = 1, CategoryName = "Miscellaneous"},
            new Category {CategoryID = 2, CategoryName = "Drama"},
            new Category {CategoryID = 3, CategoryName = "Television"},
            new Category {CategoryID = 4, CategoryName = "Horror/Suspense"},
            new Category {CategoryID = 5, CategoryName = "Comedy"},
            new Category {CategoryID = 6, CategoryName = "Family"},
            new Category {CategoryID = 7, CategoryName = "Action/Adventure"},
            new Category {CategoryID = 8, CategoryName = "VHS"}
        );
    }
}