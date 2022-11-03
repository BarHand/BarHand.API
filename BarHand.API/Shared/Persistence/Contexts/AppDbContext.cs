using BarHand.API.Inventory.Domain.Models;
using BarHand.API.Shared.Extensions;
using Microsoft.EntityFrameworkCore;

namespace BarHand.API.Shared.Persistence.Contexts;

public class AppDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        //Products Configuration
        builder.Entity<Product>().ToTable("Products");
        builder.Entity<Product>().HasKey(p => p.Id);
        builder.Entity<Product>().Property(p => p.Id)
            .IsRequired().ValueGeneratedOnAdd();// is required
        builder.Entity<Product>().Property(p => p.Name)
            .IsRequired().HasMaxLength(200);//tamaño max de 200 
        builder.Entity<Product>().Property(p => p.Category)
            .IsRequired().HasMaxLength(200);
        builder.Entity<Product>().Property(p => p.Description)
            .IsRequired().HasMaxLength(200);;
        builder.Entity<Product>().Property(p => p.NumberOfSales)
            .IsRequired();
        builder.Entity<Product>().Property(p => p.Available)
            .IsRequired();
        
        
        builder.UseSnakeCaseNamingConvention();
    }
}