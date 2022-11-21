using BarHand.API.Inventory.Domain.Models;
using BarHand.API.Notifications.Domain.Models;
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

    public DbSet<Notification> Notifications { get; set; }

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
        builder.Entity<Store>().Property(p => p.StoreName)
            .IsRequired().HasMaxLength(200);
        builder.Entity<Store>().Property(p => p.Address)
            .IsRequired().HasMaxLength(200);
        builder.Entity<Store>().Property(p => p.Phone)
            .IsRequired();
        builder.Entity<Store>().Property(p => p.Email)
            .IsRequired().HasMaxLength(200);
        builder.Entity<Store>().Property(p => p.Password)
            .IsRequired().HasMaxLength(200);
        builder.Entity<Store>().Property(p => p.Image)
            .IsRequired().HasMaxLength(1000);
        builder.Entity<Store>().Property(p => p.Name)
            .IsRequired().HasMaxLength(200);
        builder.Entity<Store>().Property(p => p.LastName)
            .IsRequired().HasMaxLength(200);

        //Notifications
        builder.Entity<Notification>().ToTable("Notifications");
        builder.Entity<Notification>().HasKey(p => p.Id);
        builder.Entity<Notification>().Property(p => p.Id)
            .IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Notification>().Property(p => p.Title)
            .IsRequired().HasMaxLength(100);
        builder.Entity<Notification>().Property(p => p.Content)
            .IsRequired().HasMaxLength(275);
        builder.Entity<Notification>().Property(p => p.Type)
            .IsRequired().HasMaxLength(25);
        builder.Entity<Notification>().Property(p => p.TypeId)
            .IsRequired().HasMaxLength(25);



        //Relationships
        /* builder.Entity<Supplier>()
            .HasMany(p => p.Products)
             .WithOne(p => p.Supplier)
            .HasForeignKey(p => p.SupplierId);*/

        //Relationships
        /* builder.Entity<Supplier>()
             .HasMany(p => p.Notifications)
             .WithOne(p => p.Supplier)
             .HasForeignKey(p => p.SupplierId).OnDelete(DeleteBehavior.SetNull); */

        /*builder.Entity<Store>()
            .HasMany(p => p.Notifications)
            .WithOne(p => p.Store)
            .HasForeignKey(p => p.StoreId).OnDelete(DeleteBehavior.SetNull); */


        //Apply Snake Case Naming Convention
        builder.UseSnakeCaseNamingConvention();
    }
}