using System.ComponentModel.DataAnnotations.Schema;
using BarHand.API.Inventory.Domain.Models;

namespace BarHand.API.Stores.Domain.Models;

[Table("Stores")]
public class Store
{
    public Store()
    {
        Products = new List<Product>();
    }
    
    public int Id { get; set; }
    
    public string storeName { get; set; }
    
    public string address { get; set; }
    
    public string ruc { get; set; }
    
    public string Category { get; set; }
    
    public string Description { get; set; }
    
    public long Phone { get; set; }
    
    public string Email { get; set; }
    
    public string Password { get; set; }
    
    public  List<Product> Products { get; set; }
}

