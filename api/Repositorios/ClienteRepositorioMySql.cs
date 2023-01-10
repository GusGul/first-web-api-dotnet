﻿using first_web_api_dotnet.Models;
using first_web_api_dotnet.Repositorios.Interfaces;
using MySql.Data.MySqlClient;

namespace first_web_api_dotnet.Repositorios
{
    public class ClienteRepositorioMySql : IServico
    {
        public ClienteRepositorioMySql()
        {
            conexao = Environment.GetEnvironmentVariable("DATABASE_URL_CDF");
            if (conexao is null) conexao = "Server=localhost;Database=locacao_carros;Uid=root;Pwd=179179;";
        }

        public string? conexao = null;

        public List<Cliente> Todos()
        {
            var lista = new List<Cliente>();
            using (var conn = new MySqlConnection(conexao))
            {
                conn.Open();
                var query = $"select * from clientes";

                var command = new MySqlCommand(query, conn);
                var dr = command.ExecuteReader();
                while (dr.Read())
                {
                    lista.Add(new Cliente
                    {
                        Id = Convert.ToInt32(dr["id"]),
                        Nome = dr["nome"].ToString() ?? "",
                        Telefone = dr["telefone"].ToString() ?? "",
                        Email = dr["email"].ToString() ?? "",
                        Endereco = dr["endereco"].ToString() ?? "",
                    });
                }

                conn.Close();
            }

            return lista;
        }

        public void Incluir(Cliente cliente)
        {
            using (var conn = new MySqlConnection(conexao))
            {
                conn.Open();
                var query = $"insert into clientes(nome,telefone,email,endereco)values(@nome,@telefone,@email,@endereco);";
                var command = new MySqlCommand(query, conn);
                command.Parameters.Add(new MySqlParameter("@nome", cliente.Nome));
                command.Parameters.Add(new MySqlParameter("@telefone", cliente.Telefone));
                command.Parameters.Add(new MySqlParameter("@email", cliente.Email));
                command.Parameters.Add(new MySqlParameter("@endereco", cliente.Endereco));
                command.ExecuteNonQuery();

                // caso queira trabalhar com o ID retornado 
                // int id = Convert.ToInt32(command.ExecuteScalar());
                conn.Close();
            }
        }

        public Cliente Atualizar(Cliente cliente)
        {
            using (var conn = new MySqlConnection(conexao))
            {
                conn.Open();
                var query = $"update clientes set nome=@nome,telefone=@telefone,email=@email,endereco=@endereco where id = @id;";
                var command = new MySqlCommand(query, conn);
                command.Parameters.Add(new MySqlParameter("@id", cliente.Id));
                command.Parameters.Add(new MySqlParameter("@nome", cliente.Nome));
                command.Parameters.Add(new MySqlParameter("@telefone", cliente.Telefone));
                command.Parameters.Add(new MySqlParameter("@email", cliente.Email));
                command.Parameters.Add(new MySqlParameter("@endereco", cliente.Endereco));
                command.ExecuteNonQuery();

                conn.Close();
            }

            return cliente;
        }

        public void Apagar(Cliente cliente)
        {
            using (var conn = new MySqlConnection(conexao))
            {
                conn.Open();
                var query = $"delete from clientes where id = @id;";
                var command = new MySqlCommand(query, conn);
                command.Parameters.Add(new MySqlParameter("@id", cliente.Id));
                command.ExecuteNonQuery();
                conn.Close();
            }
        }
    }
}
