using bagit_api.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace bagit_api.Data;

public class BagItDbContext : IdentityDbContext
{
    public BagItDbContext(DbContextOptions<BagItDbContext> options)
        : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        base.OnModelCreating(modelBuilder);
   
        // modelBuilder.Entity<Game>().HasData(SeedData.GetGames());
    }
    
    public DbSet<User> Users { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ShoppingList> Lists { get; set; }
}
