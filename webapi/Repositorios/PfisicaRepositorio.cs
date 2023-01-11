using MySql.Data.MySqlClient;
using webapi.Models;
using webapi.Repositorios.Interfaces;

namespace webapi.Repositorios
{
    public class PfisicaRepositorio : IServico<PessoaFisica>
    {
        public PfisicaRepositorio()
        {
            conexao = Environment.GetEnvironmentVariable("DATABASE_URL_CDF");
            if (conexao is null) conexao = "Server=localhost;Database=empresa;Uid=root;Pwd=179179;";
        }

        private string? conexao = null;

        public async Task<List<PessoaFisica>> TodosAsync()
        {
            var lista = new List<PessoaFisica>();
            using(var conn = new MySqlConnection(conexao))
            {
                conn.Open();

                var query = $"select * from clientes";

                var cmd = new MySqlCommand(query, conn);
                var dr = await cmd.ExecuteReaderAsync();
                while (dr.Read())
                {
                    lista.Add(new PessoaFisica
                    {
                        Id = Convert.ToInt32(dr["id"]),
                        Nome = dr["nome"].ToString() ?? "",
                        Telefone = ,
                        Email = ,
                        Endereco = ,
                    });
                }

                conn.Close();
            }

            return lista;
        }

        public async Task IncluirAsync(PessoaFisica t)
        {
            throw new NotImplementedException();
        }

        public async Task<PessoaFisica> AtualizarAsync(PessoaFisica t)
        {
            throw new NotImplementedException();
        }
                
        public async Task ApagarAsync(PessoaFisica t)
        {
            throw new NotImplementedException();
        }
    }
}
