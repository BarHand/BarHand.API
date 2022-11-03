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
        return await _context.Products
            .Include(p => p.Supplier)
            .ToListAsync();
    }

    public async Task AddAsync(Product product)
    {
        await _context.Products.AddAsync(product);
    }

    public async Task<Product> FindByAsync(long id)
    {
        return await _context.Products.FindAsync(id);
    }

    public async Task<Product> FindByTitleAsync(string title)
    {
        return await _context.Products
            .Include(p => p.Category)
            .FirstOrDefaultAsync(p => p.Name == title);
    }

    public async Task<IEnumerable<Product>> FindBySupplierIdAsync(long supplierId)
    {
        return await _context.Products
            .Where(p => p.SupplierId == supplierId)
            .Include(p => p.Supplier)
            .ToListAsync();
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