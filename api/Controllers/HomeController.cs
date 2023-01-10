using first_web_api_dotnet.ModelViews;
using Microsoft.AspNetCore.Mvc;

namespace first_web_api_dotnet.Controllers;

[ApiController]
[Route("/")]
public class HomeController : ControllerBase
{
    [HttpGet]
    public ActionResult Index()
    {
        return StatusCode(200, new Home
        {
            Mensagem = "Bem vindo a minha API"
        });
    }
}
