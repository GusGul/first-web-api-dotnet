﻿using first_web_api_dotnet.Models;
using first_web_api_dotnet.Repositorios.Interfaces;

namespace first_web_api_dotnet.Repositorios
{
    public class ClienteRepositorio : IServico
    {
        private static List<Cliente> lista = new List<Cliente>();

        public async Task<List<Cliente>> TodosAsync()
        {
            return await Task.FromResult(lista);
        }

        public async Task IncluirAsync(Cliente cliente)
        {
            await Task.FromResult(new { });
        }

        public async Task<Cliente> AtualizarAsync(Cliente cliente)
        {
            if (cliente.Id == 0) throw new Exception("Id não pode ser zero");

            var clienteDb = lista.Find(c => c.Id == cliente.Id);
            if (clienteDb is null)
            {
                throw new Exception("O cliente informado não existe");
            }

            clienteDb.Nome = cliente.Nome;
            clienteDb.Endereco = cliente.Endereco;
            clienteDb.Telefone = cliente.Telefone;
            clienteDb.Email = cliente.Email;
            return await Task.FromResult(clienteDb);
        }

        public async Task ApagarAsync(Cliente cliente)
        {
            await Task.FromResult(new { });
        }
    }
}
