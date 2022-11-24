using System.Net.Mime;
using AutoMapper;
using BarHand.API.Inventory.Domain.Models;
using BarHand.API.Inventory.Resources;
using BarHand.API.SalesOrders.Domain.Models;
using BarHand.API.SalesOrders.Resources;
using BarHand.API.SalesOrders.Services;
using BarHand.API.Shared.Extensions;
using BarHand.API.Stores.Domain.Services;
using BarHand.API.Suppliers.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;


namespace BarHand.API.SalesOrders.Controllers;

[ApiController]
[Route("/api/v1/stores/{storeId}/orders")]
[Produces(MediaTypeNames.Application.Json)]
public class StoreOrdersController:ControllerBase
{
    private readonly IOrderService _orderService;
    private readonly IMapper _mapper;
    private readonly IStoreService _storeService;

    public StoreOrdersController(IOrderService orderService, IMapper mapper,IStoreService storeService)
    {
        _orderService = orderService;
        _mapper = mapper;
        _storeService = storeService;
    }
    
    [HttpGet]
    [SwaggerOperation(
       
        Tags = new []{"Stores"}
    )]
    public async Task<IEnumerable<OrderResource>> GetAllOrdersByStoreIdAsync(long storeId)
    {
        var products = await _orderService.ListByStoreIdAsync(storeId);

        var resources = _mapper.Map<IEnumerable<Order>, IEnumerable<OrderResource>>(products);

        return resources;
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync( long id )
    {
        var result = await _orderService.GetByIdAsync(id);
        if (!result.Success)
            return BadRequest(result.Message);

        var orderResult = _mapper.Map<Order, OrderResource>(result.Resource);

        return Ok(orderResult);
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync( long storeId)
    {
        //added product
        _storeService.AddOrderToSupplier(storeId);
        var order1 =  _storeService.AddOrderToSupplier(storeId);
        
        //mostrar
        
        return Created(nameof(PostAsync),storeId);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(long id, [FromBody] SaveOrderResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        
        var order = _mapper.Map<SaveOrderResource, Order>(resource);

        var result = await _orderService.UpdateAsync(id, order);
        
        if (!result.Success)
            return BadRequest(result.Message);

        var orderResource = _mapper.Map<Order, OrderResource>(result.Resource);

        return Ok(orderResource);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(long id)
    {
        var result = await _orderService.DeleteAsync(id);
        
        if (!result.Success)
            return BadRequest(result.Message);

        var orderResource = _mapper.Map<Order, OrderResource>(result.Resource);

        return Ok(orderResource);
    }
}