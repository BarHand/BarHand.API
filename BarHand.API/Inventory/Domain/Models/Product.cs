using BarHand.API.Suppliers.Domain.Models;

namespace BarHand.API.Inventory.Domain.Models;

public class Product
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Category { get; set; }
    public string Description { get; set; }
    public int NumberOfSales { get; set; }
    public bool Available { get; set; }
    
    //Relationship
    public long SupplierId { get; set; }
    public Supplier Supplier { get; set; }
   
    
    
    
}