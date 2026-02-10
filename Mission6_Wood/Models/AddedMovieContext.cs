using Microsoft.EntityFrameworkCore;

namespace Mission6_Wood.Models;

public class DatingApplicationContext : DbContext
{
    public DatingApplicationContext(DbContextOptions<DatingApplicationContext> options) : base(options)
    {
        
    }
    
    public DbSet<Movie> Movies { get; set; }
}