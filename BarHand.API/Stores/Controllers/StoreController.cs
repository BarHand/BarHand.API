using AutoMapper;
using BarHand.API.Inventory.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using BarHand.API.Stores.Domain.Services;
using BarHand.API.Inventory.Domain.Models;
using BarHand.API.Inventory.Resources;
using BarHand.API.Inventory.Services;
using BarHand.API.Stores.Domain.Models;
using BarHand.API.Stores.Resources;
using BarHand.API.Suppliers.Domain.Models;
using BarHand.API.Suppliers.Resources;
using BarHand.API.Shared.Extensions;





namespace BarHand.API.Stores.Controllers;


[ApiController]
[Route("/api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class StoreController:ControllerBase
{

    private readonly IStoreService _storeService;
    private readonly IMapper _mapper;

    public StoreController(IStoreService storeService, IMapper mapper)
    {
        _storeService = storeService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<StoreResource>> GetAllAsync()
    {
        var stores = await _storeService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Store>, IEnumerable<StoreResource>>(stores);
        return resources;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveStoreResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var product = _mapper.Map<SaveStoreResource, Store>(resource);

        var result = await _storeService.SaveAsync(product);

        if (!result.Success)
            return BadRequest(result.Message);

      var storeResource = _mapper.Map<Store, StoreResource>(result.Resource);
        return Created(nameof(PostAsync), resource);
    }

}