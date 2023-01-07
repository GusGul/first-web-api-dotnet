using first_web_api_dotnet.Models;
using Microsoft.AspNetCore.Mvc;

namespace first_web_api_dotnet.Controllers;

[ApiController]
[Route("/clientes")]
public class ClientesController : ControllerBase
{
    [HttpGet("")]
    public ActionResult Index()
    {
        return StatusCode(200, new Cliente
        {
            Id = 1,
            Nome = "Gustavo",
        });
    }
}
