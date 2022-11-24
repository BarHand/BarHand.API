﻿using AutoMapper;
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

public class ResourceToModelProfile:Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<SaveProductResource, Product>();
        CreateMap<SaveSupplierResource, Supplier>();
        CreateMap<UpdateStoreResource, Store>();
        CreateMap<UpdateSupplierResource, Supplier>();
        CreateMap<SaveStoreResource, Store>();
        CreateMap<SaveNotificationResource, Notification>();
        CreateMap<SaveOrderResource, Order>();
        CreateMap<SaveOrderDetailResource, OrderDetail>();
    }
}