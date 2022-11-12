using System.Net.Mime;
using AutoMapper;
using BarHand.API.Shared.Extensions;
using BarHand.API.Stores.Domain.Models;
using BarHand.API.Stores.Domain.Services;
using BarHand.API.Stores.Resources;
using Microsoft.AspNetCore.Mvc;

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
        return Created(nameof(PostAsync),storeResource);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(long storeId, [FromBody] SaveStoreResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        
        var store = _mapper.Map<SaveStoreResource, Store>(resource);

        var result = await _storeService.UpdateAsync(storeId, store);
        
        if (!result.Success)
            return BadRequest(result.Message);

        var storeResource = _mapper.Map<Store, StoreResource>(result.Resource);

        return Ok(storeResource);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(long storeId)
    {
        var result = await _storeService.DeleteAsync(storeId);
        
        if (!result.Success)
            return BadRequest(result.Message);

        var storeResource = _mapper.Map<Store, StoreResource>(result.Resource);

        return Ok(storeResource);
    }
}
