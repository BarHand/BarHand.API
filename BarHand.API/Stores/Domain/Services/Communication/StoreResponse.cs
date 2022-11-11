using BarHand.API.Shared.Domain.Services.Communication;
using BarHand.API.Stores.Domain.Models;

namespace BarHand.API.Stores.Domain.Services.Communication;

public class StoreResponse :BaseResponse<Store>
{
    public StoreResponse(string message) : base(message)
    {
    }

    public StoreResponse(Store resource) : base(resource)
    {
    }
}