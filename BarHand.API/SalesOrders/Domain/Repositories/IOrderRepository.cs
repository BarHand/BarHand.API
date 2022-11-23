using BarHand.API.SalesOrders.Domain.Models;

namespace BarHand.API.SalesOrders.Domain.Repositories;

public interface IOrderRepository
{
    Task<IEnumerable<Order>> ListAsync();
    Task AddAsync(Order order);
    Task<Order> FindByIdAsync(long id);
    Task<IEnumerable<Order>> FindByStoreIdAsync(long storeId);
    void Update(Order product);
    void Remove(Order order);
}