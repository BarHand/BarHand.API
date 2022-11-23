namespace BarHand.API.Sales.Domain.Models;

public class Sales{
    public int Id {get; set;}
    public long IdStore {get; set;}
    public long IdProduct {get; set;}
    public bool Available {get;set;}
    public decimal Stars {get;set;}
}