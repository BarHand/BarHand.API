using BarHand.API.Stores.Domain.Models;

namespace BarHand.API.Stores.Domain.Repositories;

public interface IStoreRepository
{
    Task<IEnumerable<Store>> ListAsync();

    Task AddAsync(Store store);

    Task<Store> FindByIdAsync(long id);

    void Update(Store store);

    void Remove(Store store);

}