using BarHand.API.Inventory.Domain.Models;
using BarHand.API.Inventory.Domain.Repositories;
using BarHand.API.Inventory.Domain.Services;
using BarHand.API.Inventory.Domain.Services.Communication;
using BarHand.API.Shared.Domain.Repositories;
using BarHand.API.Suppliers.Domain.Repositories;

namespace BarHand.API.Inventory.Services;

public class ProductService: IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ISupplierRepository _supplierRepository;

    public ProductService(IProductRepository productRepository, IUnitOfWork unitOfWork, ISupplierRepository supplierRepository)
    {
        _productRepository = productRepository;
        _unitOfWork = unitOfWork;
        _supplierRepository = supplierRepository;
    }


    public async Task<IEnumerable<Product>> ListAsync()
    {
        return await _productRepository.ListAsync();
    }

    public async Task<IEnumerable<Product>> ListBySupplierIdAsync(long supplierId)
    {
        return await _productRepository.FindBySupplierIdAsync(supplierId);
    }

    public async Task<ProductResponse> GetByIdAsync(long id)
    {
        var existingProduct = await _productRepository.FindByIdAsync(id);

        if (existingProduct == null)
            return new ProductResponse("Product not found.");

        return new ProductResponse(existingProduct);
    }

    public async Task<ProductResponse> SaveAsync(Product product)
    {
        //validate existence of assigned Supplier
        var existingSupplier = await _supplierRepository.FindByIdAsync(product.SupplierId);
        if (existingSupplier == null)
            return new ProductResponse("Invalid Supplier");
        
        //Validate if title is already used
        var existingProductWithTitle=await _productRepository.FindByTitleAsync(product.Name);

        if (existingProductWithTitle != null)
            return new ProductResponse("Product name already exists.");
        
        //Perform Adding
        try
        {
            //add Product
            await _productRepository.AddAsync(product);
            
            //Complete transaction 
            await _unitOfWork.CompleteAsync();
            
            //Return Response
            return new ProductResponse(product);

        }
        catch (Exception e)
        {
            //Error handling
            return new ProductResponse($"An error  occurred saving the product: {e.Message}");
        }
    }

    public async Task<ProductResponse> UpdateAsync( long productId,Product product)
    {
        //validate if product exists
        var existingProduct=await _productRepository.FindByIdAsync(productId);
        
        if (existingProduct == null)
            return new ProductResponse("Product not found");

        //validate existence of assigned supplier
        var existingSupplier = await _supplierRepository.FindByIdAsync(product.SupplierId);
        if (existingSupplier == null)
            return new ProductResponse("Invalid Supplier");
        
        //Validate if title is already used
        var existingProductWithTitle=await _productRepository.FindByTitleAsync(product.Name);

        if (existingProductWithTitle != null && existingProductWithTitle.Id !=existingProduct.Id)
            return new ProductResponse("Product name already exists.");
        
        //Modify field
        existingProduct.Name = product.Name;
        existingProduct.Description = product.Description;
        existingProduct.Available = product.Available;
        existingProduct.NumberOfSales = product.NumberOfSales;

        //perform update
        try
        {
            _productRepository.Update(existingProduct);
            await _unitOfWork.CompleteAsync();

            return new ProductResponse(existingProduct);
        }
        catch (Exception e)
        {
            //Error handling
            return new ProductResponse($"An error  occurred while updating the product: {e.Message}");
        }

    }

    public async Task<ProductResponse> DeleteAsync(long productId)
    {
        //Validate Products existence
        var existingProduct=await _productRepository.FindByIdAsync(productId);
        if (existingProduct == null)
            return new ProductResponse("Product not found");
        //Perform delete

        try
        {
            _productRepository.Remove(existingProduct);
            await _unitOfWork.CompleteAsync();

            return new ProductResponse(existingProduct);
        }
        catch (Exception e)
        {
            //Error Handling
            return new ProductResponse($"An error occurred while deleting the product:{e.Message}");
        }

    }
}