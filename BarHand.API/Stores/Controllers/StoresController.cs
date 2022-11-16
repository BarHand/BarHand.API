using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using BarHand.API.Stores.Domain.Services;
using BarHand.API.Stores.Domain.Models;
using BarHand.API.Stores.Resources;
using BarHand.API.Shared.Extensions;


namespace BarHand.API.Stores.Controllers;


[ApiController]
[Route("/api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class StoresController:ControllerBase
{

    private readonly IStoreService _storeService;
    private readonly IMapper _mapper;

    public StoresController(IStoreService storeService, IMapper mapper)
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
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(long id)
    {
        var result = await _storeService.GetByIdAsync(id);
        if (!result.Success)
            return BadRequest(result.Message);

        var storeResult = _mapper.Map<Store, StoreResource>(result.Resource);

        return Ok(storeResult);
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveStoreResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var store = _mapper.Map<SaveStoreResource, Store>(resource);

        var result = await _storeService.SaveAsync(store);

        if (!result.Success)
            return BadRequest(result.Message);

        var storeResource = _mapper.Map<Store, StoreResource>(result.Resource);
        return Created(nameof(PostAsync), storeResource);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(long id, [FromBody] UpdateStoreResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        
        var store = _mapper.Map<UpdateStoreResource, Store>(resource);

        var result = await _storeService.UpdateAsync(id, store);
        
        if (!result.Success)
            return BadRequest(result.Message);

        var storeResource = _mapper.Map<Store, StoreResource>(result.Resource);

        return Ok(storeResource);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(long id)
    {
        var result = await _storeService.DeleteAsync(id);
        
        if (!result.Success)
            return BadRequest(result.Message);

        var storeResource = _mapper.Map<Store, StoreResource>(result.Resource);

        return Ok(storeResource);
    }

}