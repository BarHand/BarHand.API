using BarHand.API.SalesOrders.Domain.Models;
using BarHand.API.Shared.Domain.Services.Communication;

namespace BarHand.API.SalesOrders.Services.Communication;

public class OrderDetailResponse:BaseResponse<OrderDetail>
{
    public OrderDetailResponse(string message) : base(message)
    {
    }

    public OrderDetailResponse(OrderDetail resource) : base(resource)
    {
    }
}