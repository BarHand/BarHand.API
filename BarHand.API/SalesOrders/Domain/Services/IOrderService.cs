using BarHand.API.SalesOrders.Domain.Models;
using BarHand.API.SalesOrders.Services.Communication;

namespace BarHand.API.SalesOrders.Services;

public interface IOrderService
{
    Task<IEnumerable<Order>> ListAsync();
    Task<IEnumerable<Order>> ListByStoreIdAsync(long storeId);
    Task<OrderResponse> GetByIdAsync(long id);
    Task<OrderResponse> SaveAsync(Order order);
    
    Task<OrderResponse> UpdateAsync( long id,Order order);
    Task<OrderResponse> DeleteAsync(long id);
}