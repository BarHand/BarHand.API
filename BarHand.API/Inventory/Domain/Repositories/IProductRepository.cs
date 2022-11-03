

using BarHand.API.Inventory.Domain.Models;

namespace BarHand.API.Inventory.Domain.Repositories;

public interface IProductRepository
{
    Task<IEnumerable<Product>> ListAsync();
    Task AddAsync(Product product);
    Task<Product> FindByAsync(long id);
    Task<Product> FindByTitleAsync(string title);
    Task<IEnumerable<Product>> FindBySupplierIdAsync(long supplierId);
    void Update(Product product);
    void Remove(Product product);
}