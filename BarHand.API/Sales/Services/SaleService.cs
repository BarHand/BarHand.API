using BarHand.API.Shared.Domain.Repositories;
using BarHand.API.Sales.Domain.Models;
using BarHand.API.Sales.Domain.Repositories;
using BarHand.API.Sales.Domain.Services;
using BarHand.API.Sales.Domain.Services.Communication;

namespace BarHand.API.Sales.Services;

public class SaleService:ISaleService
{

    private readonly ISaleRepository _saleRepository;
    private readonly IUnitOfWork _unitOfWork;

    public SupplierService(ISaleRepository saleRepository, IUnitOfWork unitOfWork)
    {
        _saleRepository = saleRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Sales>> ListAsync()
    {
        return await _saleRepository.ListAsync();
    }

    public async Task<SaleResponse> GetByIdAsync(long id)
    {
        var existingSale = await _saleRepository.FindByIdAsync(id);
        if (existingSale == null)
            return new SaleResponse("Order not found");

        return new SaleResponse(existingSale);
    }

    public async Task<SaleResponse> SaveAsync(Sales sale)
    {
        try
        {
            await _saleRepository.AddAsync(sale);
            await _unitOfWork.CompleteAsync();
            return new SaleResponse(sale);
        }
        catch (Exception e)
        {
            return new SaleResponse($"An error occurred while saving the sale: {e.Message}");
        }
    }

    public async Task<SaleResponse> UpdateAsync(long saleId, Sales sale)
    {
        var existingSale = await _saleRepository.FindByIdAsync(saleId);
        if (existingSale == null)
        {
            return new SaleResponse("Order not found ");
        }

        try
        {
            _saleRepository.Update(existingSale);
            await _unitOfWork.CompleteAsync();

            return new SaleResponse(existingSupplier);
        }
        catch (Exception e)
        {
            return new SaleResponse($"An error occurred while updating the order: {e.Message}");
        }
    }

    public async Task<SaleResponse> DeleteAsync(long id)
    {
        var existingSale = await _saleRepository.FindByIdAsync(id);

        if (existingSale == null)
            return new SaleResponse("Order not found.");

        try
        {
            _saleRepository.Remove(existingSale);
            await _unitOfWork.CompleteAsync();

            return new SaleResponse(existingSupplier);
        }
        catch (Exception e)
        {
            return new SaleResponse($"An error occurred while deleting the order: {e.Message}");
        }
    }
}