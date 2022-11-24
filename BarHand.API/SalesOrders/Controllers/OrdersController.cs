using System.Net.Mime;
using AutoMapper;
using BarHand.API.SalesOrders.Domain.Models;
using BarHand.API.SalesOrders.Resources;
using BarHand.API.SalesOrders.Services;
using Microsoft.AspNetCore.Mvc;

namespace BarHand.API.SalesOrders.Controllers;
[ApiController]
[Route("/api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class OrdersController:ControllerBase
{
    private readonly IOrderService _orderService;
    private readonly IMapper _mapper;
    
    public OrdersController(IOrderService orderService, IMapper mapper)
    {
        _orderService = orderService;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<IEnumerable<OrderResource>> GetAllAsync()
    {
        var orders = await _orderService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Order>, IEnumerable<OrderResource>>(orders);
        return resources;
    }
}

