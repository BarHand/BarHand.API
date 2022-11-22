using BarHand.API.Sales.Domain.Models;
using BarHand.API.Sales.Domain.Repositories;
using BarHand.API.Shared.Persistence.Contexts;
using BarHand.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BarHand.API.Sales.Persistence.Repositories;

public class SaleRepository : BaseRepository , ISaleRepository
{
    public SaleRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Sales>> ListAsync()
    {
        return await _context.Sales.ToListAsync();
    }

    public async Task AddAsync(Sales sale)
    {
        await _context.Sales.AddAsync(sale);
    }

    public async Task<Sales> FindByAsync(int id)
    {
        return await _context.Sales.FindAsync(id);
    }

    public void Update(Sales sale)
    {
        _context.Sales.Update(sale);
    }

    public void Remove(Sales sale)
    {
        _context.Sales.Remove(sale);
    }
}