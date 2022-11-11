using BarHand.API.Shared.Persistence.Contexts;
using BarHand.API.Shared.Persistence.Repositories;
using BarHand.API.Stores.Domain.Models;
using BarHand.API.Stores.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BarHand.API.Stores.Persistence.Repositories;

public class StoreRepository : BaseRepository, IStoreRepository
{
    public StoreRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Store>> ListAsync()
    {
        return await _context.Stores.ToListAsync();
    }
    
    public async Task AddAsync(Store store)
    {
        await _context.Stores.AddAsync(store);
    }
    
    public async Task<Store> FindByIdAsync(long id)
    {
        return await _context.Stores.FindAsync(id);
    }
    
    public void Update(Store store)
    {
        _context.Stores.Update(store);
    }
    
    public void Remove(Store store)
    {
        _context.Stores.Remove(store);
    }
}