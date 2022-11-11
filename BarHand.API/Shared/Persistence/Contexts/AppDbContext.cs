using BarHand.API.Inventory.Domain.Models;
using BarHand.API.Shared.Extensions;
using BarHand.API.Suppliers.Domain.Models;
using BarHand.API.Stores.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BarHand.API.Shared.Persistence.Contexts;

public class AppDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Supplier> Suppliers { get; set; }
    
    public DbSet<Store> Stores { get; set; }

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
        
        //Supplier Configuration
        builder.Entity<Supplier>().ToTable("Supplier");
        builder.Entity<Supplier>().HasKey(p => p.Id);
        builder.Entity<Supplier>().Property(p => p.Id)
            .IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Supplier>().Property(p => p.SupplierName)
            .IsRequired().HasMaxLength(200);
        builder.Entity<Supplier>().Property(p => p.Name)
            .IsRequired().HasMaxLength(200);
        builder.Entity<Supplier>().Property(p => p.LastName)
            .IsRequired().HasMaxLength(200);
        builder.Entity<Supplier>().Property(p => p.Email)
            .IsRequired().HasMaxLength(200);
        builder.Entity<Supplier>().Property(p => p.Address)
            .IsRequired().HasMaxLength(200);
        builder.Entity<Supplier>().Property(p => p.Ruc)
            .IsRequired();
        builder.Entity<Supplier>().Property(p => p.Category)
            .IsRequired().HasMaxLength(200);
        builder.Entity<Supplier>().Property(p => p.Description)
            .IsRequired().HasMaxLength(200);
        builder.Entity<Supplier>().Property(p => p.Phone)
            .IsRequired();
        builder.Entity<Supplier>().Property(p => p.Password)
            .IsRequired().HasMaxLength(200);
        builder.Entity<Supplier>().Property(p => p.Likes)
            .IsRequired();
        
        //stores
        builder.Entity<Store>().ToTable("Stores");
        builder.Entity<Store>().HasKey(p => p.Id);
        builder.Entity<Store>().Property(p => p.Id)
            .IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Store>().Property(p => p.storeName)
            .IsRequired().HasMaxLength(200);
        builder.Entity<Store>().Property(p => p.address)
            .IsRequired().HasMaxLength(200);
        builder.Entity<Store>().Property(p => p.ruc)
            .IsRequired();
        builder.Entity<Store>().Property(p => p.Category)
            .IsRequired().HasMaxLength(200);
        builder.Entity<Store>().Property(p => p.Description)
            .IsRequired().HasMaxLength(200);
        builder.Entity<Store>().Property(p => p.Phone)
            .IsRequired();
        builder.Entity<Store>().Property(p => p.Email)
            .IsRequired().HasMaxLength(200);
        builder.Entity<Store>().Property(p => p.Password)
            .IsRequired().HasMaxLength(200);
        
        //Relationships
        builder.Entity<Supplier>()
            .HasMany(p => p.Products)
            .WithOne(p => p.Supplier)
            .HasForeignKey(p => p.SupplierId);
        


        //Apply Snake Case Naming Convention
        builder.UseSnakeCaseNamingConvention();
    }
}