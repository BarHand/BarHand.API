using System.ComponentModel.DataAnnotations;
using BarHand.API.Inventory.Resources;
namespace BarHand.API.Sales.Resources;

public class SaleResource{
    [Required]
    public long IdStore{get;set;}
    [Required]
    public long IdProduct {get;set;}
    [Required]
    public bool Available {get; set;}
}