using BarHand.API.Inventory.Domain.Models;

using BarHand.API.Notifications.Domain.Models;
using BarHand.API.SalesOrders.Domain.Models;
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
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderDetail> orderDetails { get; set; }

    public AppDbContext(DbContextOptions options) : base(options)
    {
    }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        

        //Products Configuration
        builder.Entity<Product>().ToTable("Products");
        builder.Entity<Product>().HasKey(p => p.Id);
        builder.Entity<Product>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();// is required
        builder.Entity<Product>().Property(p => p.Name).IsRequired().HasMaxLength(200);//tamaño max de 200 
        builder.Entity<Product>().Property(p => p.Category).IsRequired().HasMaxLength(200);
        builder.Entity<Product>().Property(p => p.Description).IsRequired().HasMaxLength(200);;
        builder.Entity<Product>().Property(p => p.NumberOfSales).IsRequired();
        builder.Entity<Product>().Property(p => p.Available).IsRequired();
        builder.Entity<Product>().Property(p => p.Rating).IsRequired().HasDefaultValue(1);;
        
        //Supplier Configuration
        builder.Entity<Supplier>().ToTable("Suppliers");
        builder.Entity<Supplier>().HasKey(p => p.Id);
        builder.Entity<Supplier>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Supplier>().Property(p => p.SupplierName).IsRequired().HasMaxLength(200);
        builder.Entity<Supplier>().Property(p => p.Name).IsRequired().HasMaxLength(200);
        builder.Entity<Supplier>().Property(p => p.LastName).IsRequired().HasMaxLength(200);
        builder.Entity<Supplier>().Property(p => p.Email).IsRequired().HasMaxLength(200);
        builder.Entity<Supplier>().Property(p => p.Address).HasMaxLength(200);
        builder.Entity<Supplier>().Property(p => p.Ruc);
        builder.Entity<Supplier>().Property(p => p.Category).HasMaxLength(200);
        builder.Entity<Supplier>().Property(p => p.Description).HasMaxLength(300);
        builder.Entity<Supplier>().Property(p => p.Phone);
        builder.Entity<Supplier>().Property(p => p.Password).IsRequired().HasMaxLength(200);
        builder.Entity<Supplier>().Property(p => p.Likes).HasDefaultValue(1);
        builder.Entity<Supplier>().Property(p => p.Image).HasMaxLength(300);

        //stores
        builder.Entity<Store>().ToTable("Stores");
        builder.Entity<Store>().HasKey(p => p.Id);
        builder.Entity<Store>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Store>().Property(p => p.StoreName).IsRequired().HasMaxLength(200);
        builder.Entity<Store>().Property(p => p.Address).HasMaxLength(200);
        builder.Entity<Store>().Property(p => p.Phone).ValueGeneratedNever();
        builder.Entity<Store>().Property(p => p.Email).IsRequired().HasMaxLength(200);
        builder.Entity<Store>().Property(p => p.Password).IsRequired().HasMaxLength(200);
        builder.Entity<Store>().Property(p => p.Image).HasMaxLength(1000);
        builder.Entity<Store>().Property(p => p.Name).IsRequired().HasMaxLength(200);
        builder.Entity<Store>().Property(p => p.LastName).IsRequired().HasMaxLength(200);
        
        //Order
        builder.Entity<Order>().ToTable("Orders");
        builder.Entity<Order>().Property(p => p.Id);
        builder.Entity<Order>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        
        //OrderDetail
        builder.Entity<OrderDetail>().ToTable("OrderDetails");
        builder.Entity<OrderDetail>().HasKey(p => p.Id);
        builder.Entity<OrderDetail>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<OrderDetail>().Property(p => p.Quantity).IsRequired();
        builder.Entity<OrderDetail>().Property(p => p.QuotedPrice).IsRequired();
        

        //Relationships
        builder.Entity<Supplier>()
            .HasMany(p => p.Products)
            .WithOne(p => p.Supplier)
            .HasForeignKey(p => p.SupplierId);
        
        builder.Entity<Store>()
            .HasMany(p => p.Orders)
            .WithOne(p => p.Store)
            .HasForeignKey(p => p.StoreId);
        


        //Apply Snake Case Naming Convention
        builder.UseSnakeCaseNamingConvention();
    }
}