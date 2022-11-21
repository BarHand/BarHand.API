using System.ComponentModel.DataAnnotations.Schema;
using BarHand.API.Inventory.Domain.Models;
using BarHand.API.Notifications.Domain.Models;

namespace BarHand.API.Stores.Domain.Models;


public class Store
{
   public Store()
    {
       // Products = new List<Product>();
     //  Notifications = new List<Notification>();
    }
   
    public long Id { get; set; }

    public string Name { get; set; }

    public string LastName { get; set; }

    public string StoreName { get; set; }
    
    public string Address { get; set; }

    public long Phone { get; set; }
    
    public string Email { get; set; }
    
    public string Password { get; set; }

    public string Image { get; set; }

    //  public  List<Product> Products { get; set; }

   // public List<Notification> Notifications { get; set; }
}

