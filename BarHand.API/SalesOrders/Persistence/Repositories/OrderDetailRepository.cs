using BarHand.API.SalesOrders.Domain.Models;
using BarHand.API.SalesOrders.Domain.Repositories;
using BarHand.API.Shared.Persistence.Contexts;
using BarHand.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BarHand.API.SalesOrders.Persistence.Repositories;

public class OrderDetailRepository:BaseRepository,IOrderDetailRepository
{
    public OrderDetailRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<OrderDetail>> ListAsync()
    {
        return await _context.orderDetails
            .Include(p => p.Order)
            .ToListAsync();
    }

    public async Task AddAsync(OrderDetail orderDetail)
    {
        await _context.orderDetails.AddAsync(orderDetail);
    }

    public async Task<OrderDetail> FindByIdAsync(long id)
    {
        return await _context.orderDetails.FindAsync(id);
    }

    public async Task<IEnumerable<OrderDetail>> FindByOrderIdAsync(long orderId)
    {
        return await _context.orderDetails
            .Where(p => p.OrderId == orderId)
            .Include(p => p.Order)
            .ToListAsync();
    }

    public void Update(OrderDetail orderDetail)
    {
        _context.orderDetails.Update( orderDetail);
    }

    public void Remove(OrderDetail orderDetail)
    {
        _context.orderDetails.Remove(orderDetail);
    }
}