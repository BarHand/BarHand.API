using BarHand.API.Shared.Domain.Repositories;
using BarHand.API.Suppliers.Domain.Models;
using BarHand.API.Suppliers.Domain.Repositories;
using BarHand.API.Suppliers.Domain.Services;
using BarHand.API.Suppliers.Domain.Services.Communication;

namespace BarHand.API.Suppliers.Services;

public class SupplierService:ISupplierService
{

    private readonly ISupplierRepository _supplierRepository;
    private readonly IUnitOfWork _unitOfWork;

    public SupplierService(ISupplierRepository supplierRepository, IUnitOfWork unitOfWork)
    {
        _supplierRepository = supplierRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Supplier>> ListAsync()
    {
        return await _supplierRepository.ListAsync();
    }

    public async Task<SupplierResponse> GetByIdAsync(long id)
    {
        var existingSupplier = await _supplierRepository.FindByIdAsync(id);
        if (existingSupplier == null)
            return new SupplierResponse("Supplier not found");

        return new SupplierResponse(existingSupplier);
    }

    public async Task<SupplierResponse> SaveAsync(Supplier supplier)
    {
        try
        {
            await _supplierRepository.AddAsync(supplier);
            await _unitOfWork.CompleteAsync();
            return new SupplierResponse(supplier);
        }
        catch (Exception e) 
        {
            return new SupplierResponse($"An error occurred while saving the supplier: {e.Message}");
        }
    }

    public async Task<SupplierResponse> UpdateAsync(long supplierId, Supplier supplier)
    {
        var existingSupplier = await _supplierRepository.FindByIdAsync(supplierId);
        if (existingSupplier == null)
        {
            return new SupplierResponse("Mechanic not found ");
        }
        existingSupplier.Name = supplier.Name;

        try
        {
            _supplierRepository.Update(existingSupplier);
            await _unitOfWork.CompleteAsync();

            return new SupplierResponse(existingSupplier);
        }
        catch (Exception e)
        {
            return new SupplierResponse($"An error occurred while updating the supplier: {e.Message}");
        }
    }

    public async Task<SupplierResponse> DeleteAsync(long id)
    {
        var existingSupplier = await _supplierRepository.FindByIdAsync(id);

        if (existingSupplier == null)
            return new SupplierResponse("Mechanic not found.");

        try
        {
            _supplierRepository.Remove(existingSupplier);
            await _unitOfWork.CompleteAsync();

            return new SupplierResponse(existingSupplier);
        }
        catch (Exception e)
        {
            return new SupplierResponse($"An error occurred while deleting the supplier: {e.Message}");
        }
    }
}