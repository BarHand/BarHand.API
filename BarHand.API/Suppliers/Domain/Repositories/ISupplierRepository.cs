using BarHand.API.Suppliers.Domain.Models;

namespace BarHand.API.Suppliers.Domain.Repositories;

public interface ISupplierRepository
{
    Task<IEnumerable<Supplier>> ListAsync();
    Task AddAsync(Supplier supplier);
    Task<Supplier> FindByIdAsync(long id);
    //Task<Supplier> FindByUserIdAsync(long userId);
    void Update(Supplier supplier);
    void Remove(Supplier supplier);
}