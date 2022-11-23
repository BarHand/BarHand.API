using System.ComponentModel.DataAnnotations;

namespace BarHand.API.SalesOrders.Resources;

public class SaveOrderResource
{
    [Required]
    public long StoreId { get; set; }
}