using System.ComponentModel.DataAnnotations;

namespace BarHand.API.SalesOrders.Resources;

public class SaveOrderDetailResource
{
    [Required]
    public int Quantity { get; set; }
    [Required]
    public int QuotedPrice { get; set; }
    [Required]
    public long OrderId { get; set; }
    [Required]
    public long ProductId { get; set; }
}