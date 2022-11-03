using BarHand.API.Shared.Persistence.Contexts;
using BarHand.API.Shared.Persistence.Repositories;
using BarHand.API.Suppliers.Domain.Models;
using BarHand.API.Suppliers.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BarHand.API.Suppliers.Persistence.Repositories;

public class SupplierRepository : BaseRepository, ISupplierRepository
{
    public SupplierRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Supplier>> ListAsync()
    {
        return await _context.Suppliers.ToListAsync();
    }

    public async Task AddAsync(Supplier supplier)
    {
         await _context.Suppliers.AddAsync(supplier);
    }

    public async Task<Supplier> FindByIdAsync(long id)
    {
        return await _context.Suppliers.FindAsync(id);
    }

    public void Update(Supplier supplier)
    {
        _context.Suppliers.Update(supplier);
    }

    public void Remove(Supplier supplier)
    {
        _context.Suppliers.Remove(supplier);
    }
}