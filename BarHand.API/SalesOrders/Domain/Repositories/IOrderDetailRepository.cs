using BarHand.API.SalesOrders.Domain.Models;

namespace BarHand.API.SalesOrders.Domain.Repositories;

public interface IOrderDetailRepository
{
    Task<IEnumerable<OrderDetail>> ListAsync();
    Task AddAsync(OrderDetail orderDetail);
    Task<OrderDetail> FindByIdAsync(long id);
    Task<IEnumerable<OrderDetail>> FindByOrderIdAsync(long orderId);
    void Update(OrderDetail orderDetail);
    void Remove(OrderDetail orderDetail);
}