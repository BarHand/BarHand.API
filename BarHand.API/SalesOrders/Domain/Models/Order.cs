using BarHand.API.Stores.Domain.Models;

namespace BarHand.API.SalesOrders.Domain.Models;

public class Order
{
    public long Id { get; set; }
    //relationships
    public long StoreId { get; set; }
    public Store Store { get; set; }
    public List<OrderDetail> orderDetails { get; set; }
    
}