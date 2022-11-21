using BarHand.API.Inventory.Domain.Repositories;
using BarHand.API.Inventory.Domain.Services;
using BarHand.API.Inventory.Persistence.Repositories;
using BarHand.API.Inventory.Services;
using BarHand.API.Notifications.Domain.Repositories;
using BarHand.API.Notifications.Domain.Services;
using BarHand.API.Notifications.Persistence.Repositories;
using BarHand.API.Notifications.Services;
using BarHand.API.Shared.Domain.Repositories;
using BarHand.API.Shared.Persistence.Contexts;
using BarHand.API.Shared.Persistence.Repositories;
using BarHand.API.Stores.Domain.Repositories;
using BarHand.API.Stores.Domain.Services;
using BarHand.API.Stores.Persistence.Repositories;
using BarHand.API.Stores.Services;
using BarHand.API.Suppliers.Domain.Repositories;
using BarHand.API.Suppliers.Domain.Services;
using BarHand.API.Suppliers.Persistence.Repositories;
using BarHand.API.Suppliers.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Add Data Base Connection

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(
    options=>options.UseMySQL(connectionString)
        .LogTo(Console.WriteLine,LogLevel.Information)
        .EnableSensitiveDataLogging()
        .EnableDetailedErrors());

//LowerCase URLs configuration
builder.Services.AddRouting(options => options.LowercaseUrls = true);

//Dependency Injection Configuration

// Shared Bounded Context Injection Configuration

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
 
//Inventory Bounded Context Injection Configuration
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();

//Auto Mapper Configuration
builder.Services.AddAutoMapper(
    typeof(BarHand.API.Mapping.ModelToResourceProfile),
    typeof(BarHand.API.Mapping.ResourceToModelProfile));
//Suppliers
builder.Services.AddScoped<ISupplierRepository, SupplierRepository>();
builder.Services.AddScoped<ISupplierService, SupplierService>();
//Stores
builder.Services.AddScoped<IStoreRepository, StoreRepository>();
builder.Services.AddScoped<IStoreService, StoreService>();
//Notifications
builder.Services.AddScoped<INotificationRepository, NotificationRepository>();
builder.Services.AddScoped<INotificationService, NotificationService>();

var app = builder.Build();

//Validation for ensuring Database Objects area created

using (var scope=app.Services.CreateScope())
using (var context = scope.ServiceProvider.GetService<AppDbContext>())
{
    context.Database.EnsureCreated();
}


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();