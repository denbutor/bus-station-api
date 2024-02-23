using BusStation.BLL.Interfaces;
using BusStation.Data.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;

namespace BusStation.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RouteController : ControllerBase
{
    private readonly IRouteService _service;

    public RouteController(IRouteService service)
    {
        _service = service;
    }
    
    [HttpGet("Get")]
    public async Task<ActionResult<IEnumerable<RouteDto>>> Get()
    {
        return Ok(await _service.Get());
    }
    
    [HttpPost]
    public async Task<ActionResult> Insert([FromBody] RouteDto modelDto)
    {
        return Ok(await _service.Insert(modelDto));
    }

    [HttpDelete]
    public async Task<ActionResult> DeleteById(Guid id)
    {
        return Ok(await _service.DeleteById(id));
    }
}