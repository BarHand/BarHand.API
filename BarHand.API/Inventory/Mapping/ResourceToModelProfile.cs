using AutoMapper;
using BarHand.API.Inventory.Domain.Models;
using BarHand.API.Inventory.Resources;

namespace BarHand.API.Inventory.Mapping;

public class ResourceToModelProfile:Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<SaveProductResource, Product>();
    }
}