using BarHand.API.Sales.Domain.Models;
using BarHand.API.Shared.Domain.Services.Communication;

public class SaleResponse: BaseResponse<Sales>{
    public SaleResponse(string message) : base(message){}
    public SaleResponse(Sales resource) : base(resource){}
}