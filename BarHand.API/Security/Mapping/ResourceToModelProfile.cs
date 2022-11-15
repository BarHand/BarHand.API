﻿using AutoMapper;
using BarHand.API.Security.Domain.Models;
using BarHand.API.Security.Domain.Services.Communication;

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