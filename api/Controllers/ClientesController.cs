using first_web_api_dotnet.Models;
using first_web_api_dotnet.Repositorios;
using first_web_api_dotnet.Repositorios.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace first_web_api_dotnet.Controllers;

[Route("clientes")]
public class ClientesController : ControllerBase
{
    private IServico _servico;
    public ClientesController(IServico servico)
    {
        _servico = servico;
    }

    [HttpGet("")]
    public IActionResult Index()
    {
        var clientes = _servico.Todos();
        return StatusCode(200, clientes);
    }

    [HttpGet("{id}")]
    public IActionResult Details([FromRoute] int id)
    {
        var cliente = _servico.Todos().Find(c => c.Id == id);
        return StatusCode(200, cliente);
    }


    [HttpPost("")]
    public IActionResult Create([FromBody] Cliente cliente)
    {
        _servico.Incluir(cliente);
        return StatusCode(201, cliente);
    }


    [HttpPut("{id}")]
    public IActionResult Update([FromRoute] int id, [FromBody] Cliente cliente)
    {
        if (id != cliente.Id)
        {
            return StatusCode(400, new
            {
                Mensagem = "O Id do cliente precisa bater com o id da URL"
            });
        }

        var clienteDb = _servico.Atualizar(cliente);

        return StatusCode(200, clienteDb);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete([FromRoute] int id)
    {
        var clienteDb = _servico.Todos().Find(c => c.Id == id);
        if (clienteDb is null)
        {
            return StatusCode(404, new
            {
                Mensagem = "O cliente informado não existe"
            });
        }

        _servico.Apagar(clienteDb);

        return StatusCode(204);
    }

}
