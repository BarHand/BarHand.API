using BarHand.API.Suppliers.Resources;

namespace BarHand.API.Inventory.Resources;

public class ProductResource
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Category { get; set; }
    public string Image { get; set; }
    public int Price { get; set; }
    public string Description { get; set; }
    public int NumberOfSales { get; set; }
    public bool Available { get; set; }
    public long SupplierId { get; set; }
    
    public SupplierResource Supplier { get; set; }

}