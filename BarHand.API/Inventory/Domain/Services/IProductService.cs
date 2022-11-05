﻿using BarHand.API.Inventory.Domain.Models;
using BarHand.API.Inventory.Domain.Services.Communication;
using BarHand.API.Suppliers.Domain.Models;

namespace BarHand.API.Inventory.Domain.Services;

public interface IProductService
{
    Task<IEnumerable<Product>> ListAsync();
    Task<IEnumerable<Product>> ListBySupplierIdAsync(long supplierId);
    Task<ProductResponse> SaveAsync(Product product);
    Task<ProductResponse> GetByIdAsync(long id);
    Task<ProductResponse> UpdateAsync( long productId,Product product);
    Task<ProductResponse> DeleteAsync(long productId);
    
}