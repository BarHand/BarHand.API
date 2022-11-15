using AutoMapper;
using BarHand.API.Inventory.Domain.Models;
using BarHand.API.Inventory.Resources;
using BarHand.API.Security.Domain.Models;
using BarHand.API.Security.Domain.Services.Communication;
using BarHand.API.Stores.Domain.Models;
using BarHand.API.Stores.Resources;
using BarHand.API.Suppliers.Domain.Models;
using BarHand.API.Suppliers.Resources;
using Mecanillama.API.Security.Resources;

namespace BarHand.API.Security.Mapping;

public class ModelToResourceProfile:Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<User, AuthenticateResponse>();
        CreateMap<User, UserResource>();
    }
}