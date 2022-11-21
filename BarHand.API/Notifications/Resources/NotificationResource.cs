using BarHand.API.Stores.Domain.Models;
using BarHand.API.Stores.Resources;
using BarHand.API.Suppliers.Domain.Models;
using BarHand.API.Suppliers.Resources;

namespace BarHand.API.Notifications.Resources
{
    public class NotificationResource
    {

        public long Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string Type { get; set; }

        public long TypeId { get; set; }

       // public long StoreId { get; set; }

        // public SupplierResource Supplier { get; set; }

       // public StoreResource Store { get; set; }
    }
}
