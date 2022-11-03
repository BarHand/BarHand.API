using BarHand.API.Inventory.Domain.Repositories;
using BarHand.API.Inventory.Domain.Services;
using BarHand.API.Inventory.Persistence.Repositories;
using BarHand.API.Inventory.Services;
using BarHand.API.Shared.Domain.Repositories;
using BarHand.API.Shared.Persistence.Contexts;
using BarHand.API.Shared.Persistence.Repositories;
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
    typeof(BarHand.API.Inventory.Mapping.ModelToResourceProfile),
    typeof(BarHand.API.Inventory.Mapping.ResourceToModelProfile));
//Suppliers

//Stores

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