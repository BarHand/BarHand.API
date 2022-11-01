using System.Net.Mime;
using BarHand.API.Inventory.Domain.Models;
using BarHand.API.Inventory.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace BarHand.API.Inventory.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class ProductsController:ControllerBase
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        var products = await _productService.ListAsync();
        return products;
    }
}