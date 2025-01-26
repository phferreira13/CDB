using cdbApp.Server.Interfaces;
using cdbApp.Server.Models;
using Microsoft.AspNetCore.Mvc;

namespace cdbApp.Server.Controllers;
[Route("api/cdb")]
[ApiController]
public class CdbController : ControllerBase
{
    private readonly ICdbService _cdbService;

    public CdbController(ICdbService cdbService)
    {
        _cdbService = cdbService;
    }

    [HttpGet]
    [ProducesResponseType(typeof(Cdb), StatusCodes.Status200OK)]
    public IActionResult Get([FromQuery] decimal initialValue, [FromQuery] int months)
    {
        if (initialValue <= 0 || months <= 0)
        {
            return StatusCode(StatusCodes.Status400BadRequest, "Initial value and months must be greater than 0");
        }
        var cdb = new Cdb(initialValue, months, _cdbService.GetTb(), _cdbService.GetCdi(), _cdbService.GetTax(months));
        return Ok(cdb);
    }
}
