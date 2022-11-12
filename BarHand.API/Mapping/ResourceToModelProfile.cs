using AutoMapper;
using BarHand.API.Inventory.Domain.Models;
using BarHand.API.Inventory.Resources;
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
        CreateMap<SaveStoreResource, Store>();
    }
}