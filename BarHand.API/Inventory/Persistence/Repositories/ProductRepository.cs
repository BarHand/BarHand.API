using BarHand.API.Inventory.Domain.Models;
using BarHand.API.Inventory.Domain.Repositories;
using BarHand.API.Shared.Persistence.Contexts;
using BarHand.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BarHand.API.Inventory.Persistence.Repositories;

public class ProductRepository : BaseRepository , IProductRepository
{
    public ProductRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Product>> ListAsync()
    {
        return await _context.Products.ToListAsync();
    }

    public async Task AddAsync(Product product)
    {
        await _context.Products.AddAsync(product);
    }

    public async Task<Product> FindByAsync(int id)
    {
        return await _context.Products.FindAsync(id);
    }

    public void Update(Product product)
    {
        _context.Products.Update( product);
    }

    public void Remove(Product product)
    {
        _context.Products.Remove(product);
    }
}