using Microsoft.AspNetCore.Mvc;
using Sithec.Interfaces;
using Sithec.Models.Respose;
using Sithec.Models.Request;

namespace Sithec.Controllers;
[ApiController]
[Route("controller")]
public class SithecController:ControllerBase
{
    private readonly ILogger<SithecController> _logger;
   IMock mockService;

    public SithecController(ILogger<SithecController> logger,IMock _mockService)
    {
        _logger = logger;
        mockService=_mockService;
    }

    [HttpGet]
    [Route("Mock")]
    public async Task<ActionResult<HumanoResponse>> GetMock()
    {
        HumanoResponse response = new HumanoResponse();
        response.CodigoEstatus = 200;
        response.Descripcion = "Ok";
        response.Datos = await mockService.GetMock();
        return response;
    }

    [HttpPost]
    [Route("MathOpe")]
    public async Task<ActionResult<OperacionResponse> MakeOpe(OperacionRequest request)
    {
        
    }
}

