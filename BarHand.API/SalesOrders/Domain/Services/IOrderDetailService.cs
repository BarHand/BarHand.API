using BarHand.API.SalesOrders.Domain.Models;
using BarHand.API.SalesOrders.Services.Communication;

namespace BarHand.API.SalesOrders.Services;

public interface IOrderDetailService
{
    Task<IEnumerable<OrderDetail>> ListAsync();
    Task<IEnumerable<OrderDetail>> ListByOrderIdAsync(long orderId);
    Task<OrderDetailResponse> GetByIdAsync(long id);
    Task<OrderDetailResponse> SaveAsync(OrderDetail orderDetail);
    Task<OrderDetailResponse> UpdateAsync( long id,OrderDetail orderDetail);
    Task<OrderDetailResponse> DeleteAsync(long id);
}