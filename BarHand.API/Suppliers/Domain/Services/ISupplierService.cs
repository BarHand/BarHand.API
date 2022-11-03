using BarHand.API.Suppliers.Domain.Models;
using BarHand.API.Suppliers.Domain.Services.Communication;

namespace BarHand.API.Suppliers.Domain.Services;

public interface ISupplierService
{
    Task<IEnumerable<Supplier>> ListAsync();
    Task<SupplierResponse> GetByIdAsync(long id);
    Task<SupplierResponse> SaveAsync(Supplier product);
    Task<SupplierResponse> UpdateAsync(int id, Supplier product);
    Task<SupplierResponse> DeleteAsync(int id);
}