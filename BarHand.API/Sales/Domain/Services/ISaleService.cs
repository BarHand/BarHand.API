using BarHand.API.Sales.Domain.Models;
using BarHand.API.Sales.Domain.Services.Communication;

namespace BarHand.API.Sales.Domain.Services;

public interface ISaleService{
    Task<IEnumerable<Sales>> ListAsync();
    Task<SaleResponse> SaveAsync(Sales sale);
    Task<SaleResponse> UpdateAsync(int id, Sales sale);
    Task<SaleResponse> DeleteAsync(int id);
}