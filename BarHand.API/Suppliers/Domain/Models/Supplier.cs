using BarHand.API.Inventory.Domain.Models;

namespace BarHand.API.Suppliers.Domain.Models;

public class Supplier
{
    public Supplier()
    {
        Products = new List<Product>();
    }
    //Properties
    public long Id { get; set; }
    public string SupplierName { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }
    public long Ruc { get; set; }
    public string Category { get; set; }
    public string Description { get; set; }
    public long Phone { get; set; }
    public string Password { get; set; }
    public long Likes { get; set; }
    
    public string Image { get; set; }
    
    //Relationships
    
    public  List<Product> Products { get; set; }

}