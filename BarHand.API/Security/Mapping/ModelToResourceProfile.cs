using AutoMapper;
using BarHand.API.Security.Domain.Models;
using BarHand.API.Security.Domain.Services.Communication;
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