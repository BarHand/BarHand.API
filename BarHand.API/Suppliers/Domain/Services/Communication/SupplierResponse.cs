using BarHand.API.Shared.Domain.Services.Communication;
using BarHand.API.Suppliers.Domain.Models;

namespace BarHand.API.Suppliers.Domain.Services.Communication;

public class SupplierResponse :BaseResponse<Supplier>
{
    public SupplierResponse(string message) : base(message)
    {
    }

    public SupplierResponse(Supplier resource) : base(resource)
    {
    }
}