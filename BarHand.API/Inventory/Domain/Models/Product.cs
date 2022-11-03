namespace BarHand.API.Inventory.Domain.Models;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Category { get; set; }
    public string Description { get; set; }
    public int NumberOfSales { get; set; }
    public bool Available { get; set; }
    
}