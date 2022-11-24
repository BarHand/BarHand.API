using AutoMapper;
using BarHand.API.Inventory.Domain.Models;
using BarHand.API.Inventory.Resources;
using BarHand.API.Notifications.Domain.Models;
using BarHand.API.Notifications.Resources;
using BarHand.API.SalesOrders.Domain.Models;
using BarHand.API.SalesOrders.Resources;
using BarHand.API.Stores.Domain.Models;
using BarHand.API.Stores.Resources;
using BarHand.API.Suppliers.Domain.Models;
using BarHand.API.Suppliers.Resources;

namespace BarHand.API.Mapping;

public class ModelToResourceProfile:Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<Product, ProductResource>();
        CreateMap<Supplier, SupplierResource>();
        CreateMap<Store, StoreResource>();
        CreateMap<Notification, NotificationResource>();
        CreateMap<Order, OrderResource>();
        CreateMap<OrderDetail, OrderDetailResource>();
        
    }
}