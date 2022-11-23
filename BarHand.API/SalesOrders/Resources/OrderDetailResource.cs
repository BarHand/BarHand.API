namespace BarHand.API.SalesOrders.Resources;

public class OrderDetailResource
{
    public long Id { get; set; }
    public int Quantity { get; set; }
    public int QuotedPrice { get; set; }
    public long OrderId { get; set; }
    public long ProductId { get; set; }
}