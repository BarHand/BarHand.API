using System.Collections;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using BarHand.API.Inventory.Domain.Models;
using BarHand.API.SalesOrders.Domain.Models;
using BarHand.API.Stores.Domain.Services.Communication;

namespace BarHand.API.Stores.Domain.Models;


public class Store
{
  // public Store()
   // {
   //     Products = new List<Product>();
//     }
   // 
    public long Id { get; set; }

    public string Name { get; set; }

    public string LastName { get; set; }

    public string StoreName { get; set; }

    public string? Address { get; set; }

    public long? Phone { get; set; }
    
    public string Email { get; set; }
    
    public string Password { get; set; }

    public string? Image { get; set; }
    
    //relationships

    public  ICollection<Order> Orders { get; set; }= new Collection<Order>();

    public Store addOrder()
    {
        if (Orders == null) {
            Orders = new Collection<Order>();
        }

        Order order=new Order();
            order.StoreId = this.Id;
        Orders.Add(order);
        return this;
    }


}

