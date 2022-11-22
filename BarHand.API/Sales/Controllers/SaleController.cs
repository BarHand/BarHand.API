using System.Net.Mime;
using AutoMapper;
using BarHand.API.Shared.Extensions;
using BarHand.API.Sales.Resources;
using BarHand.API.Sales.Domain.Models;
using BarHand.API.Sales.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace BarHand.API.Sales.Controllers;

[Route("/api/v1/[controller]")]
[ApiController]
[Produces(MediaTypeNames.Application.Json)]
public class SaleController: ControllerBase
{
   private readonly ISaleService _saleService;
   private readonly IMapper _mapper;

    public SalesController(ISaleService saleService, IMapper mapper)
    {
            _saleService=saleService;
            _mapper=mapper;
     }

      [HttpGet]
      public async Task<IEnumerable<ISaleService>> GetAllAsync()
      {
         var sales = await _saleService.ListAsync();
         var resources=_mapper.Map<IEnumerable<Sales>, IEnumerable<SaleResource>>(products);
         return resources;
      }
       [HttpPost]
       public async Task<IActionResult> PostAsync([FromBody] SaveSaleResource resource)
      {
        if(!ModelState.IsValid) return BadRequest(ModelState.GetErrorMessages());

         var sale =_mapper.Map<SaveSaleResource, Sales>(resource);
         var result = await _saleService.SaveAsync(sale);

         if(!result.Success) return BadRequest(result.Message);
         var saleResource = _mapper.Map<Sales, SaleResource>(result.Resources);
         return Created(nameof(PostAsync), saleResource);
      }
      [HttpPut("{id}")]
      public async Task<IActionResult> PutAsync(int id, [FromBody] SaveSaleResource resource)
      {
          if(!ModelState.IsValid) return BadRequest(ModelState.GetErrorMessages());
          var sale= _mapper.Map<SaveSaleResource, Sales>(resource);
          var result = await _saleService.UpdateAsync(id,sale);
          if(!result.Success)return BadRequest(result.Message);
          var saleResource=_mapper.Map<Sales, SaleResource>(result.Resource);
          return Ok(saleResource);
       }
       [HttpDelete("{id}")]
       public async Task<IActionResult> DeleteAsync(int id)
       {
          var result = await _saleResource.DeleteAsync(id);
          if(!result.Success)return BadRequest(result.Message);
          var saleResource = _Mapper.Map<Sales, SaleResource>(result.Resource);
          return Ok(saleResource);
       }
}
