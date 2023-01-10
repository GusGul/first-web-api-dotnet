using first_web_api_dotnet.Models;

namespace first_web_api_dotnet.Repositorios.Interfaces;

public interface IServico
{
    List<Cliente> Todos();
    void Incluir(Cliente cliente);
    Cliente Atualizar(Cliente cliente);
    void Apagar(Cliente cliente);
}