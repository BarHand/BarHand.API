using BarHand.API.Inventory.Domain.Models;
using BarHand.API.Shared.Domain.Services.Communication;

namespace BarHand.API.Inventory.Domain.Services.Communication;

public class ProductResponse: BaseResponse<Product>
{
    public ProductResponse(string message) : base(message)
    {
    }

    public ProductResponse(Product resource) : base(resource)
    {
    }
}