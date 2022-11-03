using BarHand.API.Suppliers.Domain.Models;
using BarHand.API.Suppliers.Domain.Services.Communication;

namespace BarHand.API.Suppliers.Domain.Services;

public interface ISupplierService
{
    Task<IEnumerable<Supplier>> ListAsync();
    Task<SupplierResponse> GetByIdAsync(long id);
    Task<SupplierResponse> SaveAsync(Supplier supplier);
    Task<SupplierResponse> UpdateAsync(long supplierId, Supplier supplier);
    Task<SupplierResponse> DeleteAsync(int id);
}