using BarHand.API.Inventory.Domain.Models;
using BarHand.API.Inventory.Domain.Services.Communication;

namespace BarHand.API.Inventory.Domain.Services;

public interface IProductService
{
    Task<IEnumerable<Product>> ListAsync();
    Task<ProductResponse> SaveAsync(Product product);
    Task<ProductResponse> UpdateAsync(int id, Product product);
    Task<ProductResponse> DeleteAsync(int id);
    
}