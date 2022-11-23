using BarHand.API.SalesOrders.Domain.Models;
using BarHand.API.Shared.Domain.Services.Communication;

namespace BarHand.API.SalesOrders.Services.Communication;

public class OrderResponse:BaseResponse<Order>
{
    public OrderResponse(string message) : base(message)
    {
    }

    public OrderResponse(Order resource) : base(resource)
    {
    }
}