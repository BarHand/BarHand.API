using BarHand.API.Stores.Domain.Models;
using BarHand.API.Suppliers.Domain.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BarHand.API.Notifications.Resources;

    public class SaveNotificationResource
    {
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        [Required]
        [MaxLength(275)]
        public string Content { get; set; }

        public long TypeId { get; set; }
      
      //  public long? StoreId { get; set; }

        public string Type { get; set; }


}

