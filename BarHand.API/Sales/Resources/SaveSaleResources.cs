using System.ComponentModel.DataAnnotations;

namespace Barhand.API.Sales.Resources;

public class SaleResource{
    [Required]
    public long IdStore{get;set;}
    [Required]
    public long IdSupplier {get;set;}
    [Required]
    public bool Available {get; set;}
}