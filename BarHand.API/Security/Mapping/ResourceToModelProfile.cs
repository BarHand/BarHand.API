using AutoMapper;
using BarHand.API.Inventory.Domain.Models;
using BarHand.API.Inventory.Resources;
using BarHand.API.Security.Domain.Models;
using BarHand.API.Security.Domain.Services.Communication;
using BarHand.API.Stores.Domain.Models;
using BarHand.API.Stores.Resources;
using BarHand.API.Suppliers.Domain.Models;
using BarHand.API.Suppliers.Resources;

namespace BarHand.API.Security.Mapping;

public class ResourceToModelProfile:Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<RegisterRequest, User>();

        CreateMap<UpdateRequest, User>()
            .ForAllMembers(options => options.Condition(
                (source, target, property) =>
                {
                    if (property == null) return false;
                    if (property.GetType() == typeof(string) && string.IsNullOrEmpty((string)property)) return false;
                    return true;
                }
            ));
    }
}