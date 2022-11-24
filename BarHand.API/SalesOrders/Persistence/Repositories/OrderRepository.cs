using BarHand.API.SalesOrders.Domain.Models;
using BarHand.API.SalesOrders.Domain.Repositories;
using BarHand.API.SalesOrders.Services.Communication;
using BarHand.API.Shared.Persistence.Contexts;
using BarHand.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BarHand.API.SalesOrders.Persistence.Repositories;

public class OrderRepository:BaseRepository,IOrderRepository
{
    public OrderRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Order>> ListAsync()
    {
        return await _context.Orders
            .Include(p => p.Store)
            .ToListAsync();
    }

    public async Task AddAsync(Order order)
    {
        await _context.Orders.AddAsync(order);
    }

    

    public async Task<Order> FindByIdAsync(long id)
    {
        return await _context.Orders.FindAsync(id);
    }

    public Task<OrderResponse> FindByNameAndSupplierId(long id, long storeId)
    {
        throw new NotImplementedException();
    }


    public async Task<IEnumerable<Order>> FindByStoreIdAsync(long storeId)
    {
        return await _context.Orders
            .Where(p => p.StoreId == storeId)
            .Include(p => p.Store)
            .ToListAsync();
    }

    public void Update(Order order)
    {
        _context.Orders.Update( order);
    }

    public void Remove(Order order)
    {
        _context.Orders.Remove(order);
    }
}