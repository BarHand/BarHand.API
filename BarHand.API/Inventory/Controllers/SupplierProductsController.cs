using System.Net.Mime;
using AutoMapper;
using BarHand.API.Inventory.Domain.Models;
using BarHand.API.Inventory.Domain.Services;
using BarHand.API.Inventory.Resources;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace BarHand.API.Inventory.Controllers;


[ApiController]
[Route("/api/v1/supplier/{supplierId}/products")]
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
    [SwaggerOperation(
        Summary = "Get All Products for given Supplier",
        Description = "Get existing products associated  with the specified Supplier",
        OperationId = "GetSupplierProducts",
        Tags = new []{"Supplier"}
    )]
    public async Task<IEnumerable<ProductResource>> GetAllBySupplierIdAsync(long supplierId)
    {
        var products = await _productService.ListBySupplierIdAsync(supplierId);

        var resources = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductResource>>(products);

        return resources;
    }
}