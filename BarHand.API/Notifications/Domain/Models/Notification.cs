using BarHand.API.Stores.Domain.Models;
using BarHand.API.Suppliers.Domain.Models;

namespace BarHand.API.Notifications.Domain.Models
{
    public class Notification
    {

        public long Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string Type { get; set; }
        public long TypeId { get; set; }
       // public long StoreId { get; set; }
      // public  Supplier Supplier { get; set; }
      //  public  Store Store { get; set; }


    }
}
