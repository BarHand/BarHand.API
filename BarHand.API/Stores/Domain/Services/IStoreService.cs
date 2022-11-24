using BarHand.API.SalesOrders.Domain.Models;
using BarHand.API.Stores.Domain.Models;
using BarHand.API.Stores.Domain.Services.Communication;

namespace BarHand.API.Stores.Domain.Services;

public interface IStoreService
{
    Task<IEnumerable<Store>> ListAsync();
    Task<StoreResponse> GetByIdAsync(long id);

    Task<StoreResponse> SaveAsync(Store store);

    Task<StoreResponse> UpdateAsync(long id, Store store);

    Task<StoreResponse> DeleteAsync(long id);

    Store AddOrderToSupplier(long id);
}