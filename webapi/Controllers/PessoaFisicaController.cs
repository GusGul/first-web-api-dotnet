using Microsoft.AspNetCore.Mvc;
using webapi.Repositorios.Interfaces;

namespace webapi.Controllers;

[Route("clientes")]
public class PessoaFisicaController : ControllerBase
{
    private IServico _servico;
    public PessoaFisicaController(IServico servico)
    {
        _servico = servico;
    }

    [HttpGet("")]
    public async Task<IActionResult> Index()
    {
        var clientes = await _servico.TodosAsync();
        return StatusCode(200, clientes);
    }

    
}
