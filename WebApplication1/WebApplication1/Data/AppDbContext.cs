using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data;

public class AppDbContext:IdentityDbContext<AppUser>
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    
    
    
    
    public AppDbContext(DbContextOptions options) : base(options)
    {
        
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
       modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
       base.OnModelCreating(modelBuilder);
    }

    public override int SaveChanges()
    {
        var entries = ChangeTracker.Entries<BaseEntity>();
        foreach (var entry in entries)
        {
            switch (entry.State)
            {
                case EntityState.Added:
                  entry.Entity.CreatedDate = DateTime.UtcNow;
                    break;
                case EntityState.Modified:
                    entry.Entity.UpdatedDate = DateTime.UtcNow;
                    break;
            }
        }
        return base.SaveChanges();
    }
    
}