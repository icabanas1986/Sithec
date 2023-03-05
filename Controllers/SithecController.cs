using Microsoft.AspNetCore.Mvc;
using Sithec.Interfaces;
using Sithec.Models.Respose;
using Sithec.Models.Request;
using Sithec.Models.Models;

namespace Sithec.Controllers;
[ApiController]
[Route("controller")]
public class SithecController:ControllerBase
{
    private readonly ILogger<SithecController> _logger;
   ISithec sithecService;

    public SithecController(ILogger<SithecController> logger,ISithec _sithecService)
    {
        _logger = logger;
        sithecService=_sithecService;
    }

    [HttpGet]
    [Route("Mock")]
    public async Task<ActionResult<HumanoResponse>> GetMock()
    {
        HumanoResponse response = new HumanoResponse();
        response.CodigoEstatus = 200;
        response.Descripcion = "Ok";
        response.Datos = await sithecService.GetMock();
        return response;
    }

    [HttpPost]
    [Route("MathOpe")]
    public async Task<ActionResult<OperacionResponse>> MakeOpe(OperacionRequest request)
    {
        var response = await sithecService.MakeOpe(request);
        if(response.CodigoEstatus!=200)
        {
            return BadRequest(response);
        }
        return Ok(response);
    }

    [HttpGet]
    [Route("MathHeaders")]
    public async Task<ActionResult<OperacionResponse>> MathHeaders([FromHeader]OperacionHeaderRequest request)
    {
        OperacionRequest oper = new OperacionRequest()
        {
            numerouno = request.numerouno,
            numerodos = request.numerodos,
            Operador = request.operador
        };
        var response = await sithecService.MakeOpe(oper);
        if(response.CodigoEstatus!=200)
        {
            return BadRequest(response);
        }
        return Ok(response);
    }

    [HttpPost]
    [Route("CreaHumano")]
    public async Task<ActionResult<HumanoResponse>> CreaHumano([FromBody] CreaHumanoRequest request)
    {
        var response = await sithecService.CreaHumano(request);
        if(response.CodigoEstatus!=200)
        {
            return BadRequest(response);
        }
        return Ok(response);
    }

    [HttpGet]
    [Route("ObtieneHumanos")]
    public async Task<ActionResult<HumanoResponse>> ObtieneHumanos()
    {
        var response = await sithecService.ObtieneHumanos();
        if(response.CodigoEstatus!=200)
        {
            return BadRequest(response);
        }
        return Ok(response);
    }

    [HttpGet]
    [Route("ObtieneHumano")]
    public async Task<ActionResult<HumanoResponse>> ObtieneHumano(int id)
    {
        var response = await sithecService.ObtieneHumano(id);
        if(response.CodigoEstatus!=200)
        {
            return BadRequest(response);
        }
        return Ok(response);
    }

    [HttpPut]
    [Route("ActualizaHumano")]
    public async Task<ActionResult<HumanoResponse>> ActualizaHumano(ActualizaHumanoRequest request)
    {
        var response = await sithecService.UpdateHumano(request);
        if(response.CodigoEstatus!=200)
        {
            return BadRequest(response);
        }
        return Ok(response);
    }
}


