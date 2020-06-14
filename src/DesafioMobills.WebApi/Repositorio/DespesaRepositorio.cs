using Dapper;
using DesafioMobills.WebApi.Entidades;
using DesafioMobills.WebApi.Repositorio.Interface;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace DesafioMobills.WebApi.Repositorio
{
    public class DespesaRepositorio : IRepositorio<Despesa>
    {
        private string _connectionString;
        public DespesaRepositorio(IConfiguration configuration)
        {
            _connectionString = configuration.GetSection("ConnectionStrings").GetSection("DesafioMobillsConnection").Value;
        }
        public void Adicionar(Despesa entidade)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Execute(@"INSERT INTO Despesa (Id_Conta, Descricao, Valor, Data, Pago) VALUES (@IdConta, @Descricao, @Valor, @Data, @Pago)", new
                {
                    IdConta = entidade.Id_Conta,
                    Descricao = entidade.Descricao,
                    Valor = entidade.Valor,
                    Data = entidade.Data,
                    Pago = entidade.Pago
                });
            }
        }

        public void Atualizar(Despesa entidade)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Execute(@"UPDATE Despesa SET Id_Conta = @IdConta, Descricao = @Descricao, Valor = @Valor, Data = @Data, Pago = @Pago WHERE Id = @Id", new
                {
                    IdConta = entidade.Id_Conta,
                    Descricao = entidade.Descricao,
                    Valor = entidade.Valor,
                    Data = entidade.Data,
                    Pago = entidade.Pago,
                    Id = entidade.Id
                });
            }
        }

        public void Excluir(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Execute(@"DELETE FROM Despesa WHERE Id = @Id", new { Id = id });
            }
        }

        public Despesa ObterPorId(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection
                    .QueryFirstOrDefault<Despesa>(@"SELECT Id, Id_Conta, Descricao, Valor, Data, Pago FROM Despesa WHERE Id = @Id", new { Id = id });
            }
        }

        public IList<Despesa> ObterTodos()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection
                    .Query<Despesa>("SELECT Id, Id_Conta, Descricao, Valor, Data, Pago FROM Despesa").ToList();
            }
        }

        public IList<Despesa> ListarDespesasConta(int idConta)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection
                    .Query<Despesa>("SELECT Id, Id_Conta, Descricao, Valor, Data, Pago FROM Despesa WHERE Id_Conta = @IdConta", new { @IdConta = idConta })
                    .ToList();
            }
        }
    }
}
