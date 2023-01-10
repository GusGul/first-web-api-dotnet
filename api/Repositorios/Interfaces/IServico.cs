using first_web_api_dotnet.Models;

namespace first_web_api_dotnet.Repositorios.Interfaces;

public interface IServico
{
    Task<List<Cliente>> TodosAsync();
    Task IncluirAsync(Cliente cliente);
    Task<Cliente> AtualizarAsync(Cliente cliente);
    Task ApagarAsync(Cliente cliente);
}