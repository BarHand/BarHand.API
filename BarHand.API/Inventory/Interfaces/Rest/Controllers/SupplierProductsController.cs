using System.Net.Mime;
using AutoMapper;
using BarHand.API.Inventory.Domain.Models;
using BarHand.API.Inventory.Domain.Services;
using BarHand.API.Inventory.Resources;
using Microsoft.AspNetCore.Mvc;

namespace BarHand.API.Inventory.Interfaces.Rest.Controllers;

[ApiController]
[Route("/api/v1/suppliers/{supplierId}/products")]
[Produces(MediaTypeNames.Application.Json)]
public class SupplierProductsController : ControllerBase
{
    private readonly IProductService _productService;
    private readonly IMapper _mapper;

    public SupplierProductsController(IProductService productService, IMapper mapper)
    {
        _productService = productService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<ProductResource>> GetAllBySupplierIdAsync(long supplierId)
    {
        var products = await _productService.ListBySupplierIdAsync(supplierId);

        var resources = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductResource>>(products);
        
        return resources;
    }
}