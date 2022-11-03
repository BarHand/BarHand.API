using BarHand.API.Inventory.Domain.Models;
using BarHand.API.Inventory.Domain.Repositories;
using BarHand.API.Inventory.Domain.Services;
using BarHand.API.Inventory.Domain.Services.Communication;
using BarHand.API.Shared.Domain.Repositories;

namespace BarHand.API.Inventory.Services;

public class ProductService: IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ProductService(IProductRepository productRepository, IUnitOfWork unitOfWork)
    {
        _productRepository = productRepository;
        _unitOfWork = unitOfWork;
    }


    public async Task<IEnumerable<Product>> ListAsync()
    {
        return await _productRepository.ListAsync();
    }

    public async Task<IEnumerable<Product>> ListBySupplierIdAsync(long supplierId)
    {
        return await _productRepository.FindBySupplierIdAsync(supplierId);
    }

    public async Task<ProductResponse> SaveAsync(Product product)
    {
        try
        {
            await _productRepository.AddAsync(product);
            await _unitOfWork.CompleteAsync();
            return new ProductResponse(product);
        }
        catch (Exception e)
        {
            return  new ProductResponse($"An error occurred while saving the product: {e.Message}");
            
        }
    }

    public async Task<ProductResponse> UpdateAsync(int id, Product product)
    {
        var existingProduct=await _productRepository.FindByAsync(id);
        if (existingProduct == null)
            return new ProductResponse("Product not found.");
        
        existingProduct.Name = product.Name;
        try
        {
            _productRepository.Update(existingProduct);
            await _unitOfWork.CompleteAsync();

            return new ProductResponse(existingProduct);
        }
        catch (Exception e)
        {
            return new ProductResponse($"An error occurred while updating the product:{e.Message}");
        } 
       
    }

    public async Task<ProductResponse> DeleteAsync(int id)
    {
        var existingProduct=await _productRepository.FindByAsync(id);
        if (existingProduct == null)
            return new ProductResponse("Product not found");

        try
        {
            _productRepository.Remove(existingProduct);
            await _unitOfWork.CompleteAsync();

            return new ProductResponse(existingProduct);

        }
        catch (Exception e)
        {
            return new ProductResponse($"An error occurred while deleting the product:{e.Message}");
        }

    }
}