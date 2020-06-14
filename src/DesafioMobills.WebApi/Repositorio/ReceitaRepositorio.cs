using Dapper;
using DesafioMobills.WebApi.Entidades;
using DesafioMobills.WebApi.Repositorio.Interface;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioMobills.WebApi.Repositorio
{
    public class ReceitaRepositorio : IRepositorio<Receita>
    {
        private string _connectionString;

        public ReceitaRepositorio(IConfiguration configuration)
        {
            _connectionString = configuration.GetSection("ConnectionStrings").GetSection("DesafioMobillsConnection").Value;
        }

        public void Adicionar(Receita entidade)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Execute(@"INSERT INTO Receita (Id_Conta, Descricao, Valor, Data, Recebido) VALUES (@IdConta, @Descricao, @Valor, @Data, @Recebido)", new
                {
                    IdConta = entidade.Id_Conta,
                    Descricao = entidade.Descricao,
                    Valor = entidade.Valor,
                    Data = entidade.Data,
                    Recebido = entidade.Recebido
                });
            }
        }

        public void Atualizar(Receita entidade)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Execute(@"UPDATE Receita SET Id_Conta = @IdConta, Descricao = @Descricao, Valor = @Valor, Data = @Data, Recebido = @Recebido WHERE Id = @Id", new
                {
                    IdConta = entidade.Id_Conta,
                    Descricao = entidade.Descricao,
                    Valor = entidade.Valor,
                    Data = entidade.Data,
                    Recebido = entidade.Recebido,
                    Id = entidade.Id
                });
            }
        }

        public void Excluir(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Execute(@"DELETE FROM Receita WHERE Id = @Id", new { Id = id });
            }
        }

        public Receita ObterPorId(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection
                    .QueryFirstOrDefault<Receita>(@"SELECT Id, Id_Conta, Descricao, Valor, Data, Recebido FROM Receita WHERE Id = @Id", new { Id = id });
            }
        }

        public IList<Receita> ObterTodos()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection
                    .Query<Receita>("SELECT Id, Id_Conta, Descricao, Valor, Data, Recebido FROM Receita").ToList();
            }
        }

        public IList<Receita> ListarReceitasConta(int idConta)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection
                    .Query<Receita>("SELECT Id, Id_Conta, Descricao, Valor, Data, Recebido FROM Receita WHERE Id_Conta = @IdConta", new { @IdConta = idConta })
                    .ToList();
            }
        }
    }
}
