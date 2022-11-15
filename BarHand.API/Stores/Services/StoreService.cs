using BarHand.API.Shared.Domain.Repositories;
using BarHand.API.Stores.Domain.Models;
using BarHand.API.Stores.Domain.Repositories;
using BarHand.API.Stores.Domain.Services;
using BarHand.API.Stores.Domain.Services.Communication;

namespace BarHand.API.Stores.Services;

public class StoreService : IStoreService
{
    private readonly IStoreRepository _storeRepository;
    private readonly IUnitOfWork _unitOfWork;

    public StoreService(IStoreRepository storeRepository, IUnitOfWork unitOfWork)
    {
        _storeRepository = storeRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Store>> ListAsync()
    {
        return await _storeRepository.ListAsync();
    }

    public async Task<StoreResponse> GetByIdAsync(long id)
    {
        var existingStore = await _storeRepository.FindByIdAsync(id);
        if (existingStore == null)
            return new StoreResponse("Store not found");

        return new StoreResponse(existingStore);
    }

    public async Task<StoreResponse> SaveAsync(Store store)
    {
        try
        {
            await _storeRepository.AddAsync(store);
            await _unitOfWork.CompleteAsync();
            return new StoreResponse(store);
        }
        catch (Exception e)
        {
            return new StoreResponse($"An error occurred while saving the store: {e.Message}");
        }
    }

    public async Task<StoreResponse> UpdateAsync(long storeId, Store store)
    {
        var existingStore = await _storeRepository.FindByIdAsync(storeId);
        if (existingStore == null)
        {
            return new StoreResponse("Store not found ");
        }
        

        //Modify field
        existingStore.StoreName = store.StoreName;
        existingStore.Email = store.Email;
        existingStore.Address = store.Address;
        existingStore.Name = store.Name;
        existingStore.LastName = store.LastName;
        existingStore.Phone = store.Phone;
        existingStore.Password = store.Password;
        existingStore.Image = store.Image;
        

        try
        {
            _storeRepository.Update(existingStore);
            await _unitOfWork.CompleteAsync();

            return new StoreResponse(existingStore);
        }
        catch (Exception e)
        {
            return new StoreResponse($"An error occurred while updating the store: {e.Message}");
        }
    }

    public async Task<StoreResponse> DeleteAsync(long id)
    {
        var existingStore = await _storeRepository.FindByIdAsync(id);

        if (existingStore == null)
            return new StoreResponse("Mechanic not found.");

        try
        {
            _storeRepository.Remove(existingStore);
            await _unitOfWork.CompleteAsync();

            return new StoreResponse(existingStore);
        }
        catch (Exception e)
        {
            return new StoreResponse($"An error occurred while deleting the store: {e.Message}");
        }
    }

}