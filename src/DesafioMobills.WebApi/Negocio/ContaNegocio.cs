using DesafioMobills.WebApi.Entidades;
using DesafioMobills.WebApi.Negocio.Interface;
using DesafioMobills.WebApi.Repositorio;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioMobills.WebApi.Negocio
{
    public class ContaNegocio : INegocio<Conta>
    {
        private ContaRepositorio _repositorio;
        private IConfiguration _configuration;
        private DespesaNegocio _despesaNegocio;
        private ReceitaNegocio _receitaNegocio;

        public ContaNegocio(ContaRepositorio repositorio, IConfiguration configuration, DespesaNegocio despesaNegocio, ReceitaNegocio receitaNegocio)
        {
            _repositorio = repositorio;
            _configuration = configuration;
            _despesaNegocio = despesaNegocio;
            _receitaNegocio = receitaNegocio;
        }
        public void Excluir(int id)
        {
            try
            {
                _repositorio.Excluir(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Conta ObterPorId(int id)
        {
            try
            {
                decimal totalDespesas = 0;
                decimal totalReceitas = 0;

                var contaDb = _repositorio.ObterPorId(id);

                if (contaDb != null)
                {
                    contaDb.Despesas = _despesaNegocio.ListarDespesasConta(contaDb.Id).ToList();
                    contaDb.Receitas = _receitaNegocio.ListarReceitasConta(contaDb.Id).ToList();

                    for (int i = 0; i < contaDb.Despesas.Count; i++)
                    {
                        totalDespesas += contaDb.Despesas[i].Valor;
                    }

                    for (int i = 0; i < contaDb.Receitas.Count; i++)
                    {
                        totalReceitas += contaDb.Receitas[i].Valor;
                    }

                    contaDb.SomaDespesas = totalDespesas;
                    contaDb.SomaReceitas = totalReceitas;
                    contaDb.Saldo = (totalReceitas - totalDespesas);
                }

                return contaDb;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IList<Conta> ObterTodos()
        {
            try
            {
                return _repositorio.ObterTodos();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Salvar(Conta entidade)
        {
            try
            {
                if (entidade.Id > 0)
                {
                    _repositorio.Atualizar(entidade);
                }
                else
                {
                    _repositorio.Adicionar(entidade);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
