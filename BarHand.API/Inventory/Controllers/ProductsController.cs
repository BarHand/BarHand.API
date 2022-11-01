using System.Net.Mime;
using AutoMapper;
using BarHand.API.Inventory.Domain.Models;
using BarHand.API.Inventory.Domain.Services;
using BarHand.API.Inventory.Resources;
using BarHand.API.Inventory.Services;
using Microsoft.AspNetCore.Mvc;

namespace BarHand.API.Inventory.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class ProductsController:ControllerBase
{
    private readonly IProductService _productService;
    private readonly IMapper _mapper;

    public ProductsController(IProductService productService, IMapper mapper)
    {
        _productService = productService;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<IEnumerable<ProductResource>> GetAllAsync()
    {
        var products = await _productService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductResource>>(products);
        return resources;
    }
}