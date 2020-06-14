using DesafioMobills.WebApi.Entidades;
using DesafioMobills.WebApi.Negocio.Interface;
using DesafioMobills.WebApi.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioMobills.WebApi.Negocio
{
    public class DespesaNegocio : INegocio<Despesa>
    {
        private DespesaRepositorio _repositorio;
        public DespesaNegocio(DespesaRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public void Excluir(int id)
        {
            _repositorio.Excluir(id);
        }

        public Despesa ObterPorId(int id)
        {
            try
            {
                return _repositorio.ObterPorId(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IList<Despesa> ObterTodos()
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

        public void Salvar(Despesa entidade)
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

        public IList<Despesa> ListarDespesasConta(int contaId)
        {
            try
            {
                return _repositorio.ListarDespesasConta(contaId);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
