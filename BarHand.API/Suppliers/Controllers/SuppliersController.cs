using System.Net.Mime;
using AutoMapper;
using BarHand.API.Shared.Extensions;
using BarHand.API.Suppliers.Domain.Models;
using BarHand.API.Suppliers.Domain.Services;
using BarHand.API.Suppliers.Resources;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace BarHand.API.Suppliers.Controllers;
[ApiController]
[Route("/api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Create, read, update and delete Supplier")]
public class SuppliersController:ControllerBase
{
    private readonly ISupplierService _supplierService;
    private readonly IMapper _mapper;

    public SuppliersController(ISupplierService supplierService, IMapper mapper)
    {
        _supplierService = supplierService;
        _mapper = mapper;
    }
    
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<SupplierResource>),200)]
    public async Task<IEnumerable<SupplierResource>> GetAllAsync()
    {
        var suppliers = await _supplierService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Supplier>, IEnumerable<SupplierResource>>(suppliers);
        return resources;
    }
    
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(long id)
    {
        var result = await _supplierService.GetByIdAsync(id);
        if (!result.Success)
            return BadRequest(result.Message);

        var supplierResult = _mapper.Map<Supplier, SupplierResource>(result.Resource);

        return Ok(supplierResult);
    }

    [HttpPost]
    [ProducesResponseType(typeof(SupplierResource),201)]
    [ProducesResponseType(typeof(List<String>),400)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> PostAsync([FromBody] SaveSupplierResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var product = _mapper.Map<SaveSupplierResource, Supplier>(resource);

        var result = await _supplierService.SaveAsync(product);

        if (!result.Success)
            return BadRequest(result.Message);

        var supplierResource = _mapper.Map<Supplier, SupplierResource>(result.Resource);
        return Created(nameof(PostAsync),supplierResource);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(long id, [FromBody] SaveSupplierResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        
        var supplier = _mapper.Map<SaveSupplierResource, Supplier>(resource);

        var result = await _supplierService.UpdateAsync(id, supplier);
        
        if (!result.Success)
            return BadRequest(result.Message);

        var supplierResource = _mapper.Map<Supplier, SupplierResource>(result.Resource);

        return Ok(supplierResource);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(long supplierId)
    {
        var result = await _supplierService.DeleteAsync(supplierId);
        
        if (!result.Success)
            return BadRequest(result.Message);

        var supplierResource = _mapper.Map<Supplier, SupplierResource>(result.Resource);

        return Ok(supplierResource);
    }
}