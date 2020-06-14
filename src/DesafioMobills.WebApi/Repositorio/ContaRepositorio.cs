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
    public class ContaRepositorio : IRepositorio<Conta>
    {
        private string _connectionString;

        public ContaRepositorio(IConfiguration configuration)
        {
            _connectionString = configuration
                .GetSection("ConnectionStrings")
                .GetSection("DesafioMobillsConnection")
                .Value;
        }

        public void Adicionar(Conta entidade)
        {
            throw new NotImplementedException();
        }

        public void Atualizar(Conta entidade)
        {
            throw new NotImplementedException();
        }

        public void Excluir(int id)
        {
            throw new NotImplementedException();
        }

        public Conta ObterPorId(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection
                    .QueryFirstOrDefault<Conta>(@"SELECT [Id],[Descricao] FROM [dbo].[Contas] WHERE Id = @Id", new { Id = id });
            }
        }

        public IList<Conta> ObterTodos()
        {
            throw new NotImplementedException();
        }
    }
}
