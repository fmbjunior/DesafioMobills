using DesafioMobills.WebApi.Entidades;
using DesafioMobills.WebApi.Negocio.Interface;
using DesafioMobills.WebApi.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioMobills.WebApi.Negocio
{
    public class ReceitaNegocio : INegocio<Receita>
    {
        private ReceitaRepositorio _repositorio;
        public ReceitaNegocio(ReceitaRepositorio repositorio)
        {
            _repositorio = repositorio;
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

        public Receita ObterPorId(int id)
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

        public IList<Receita> ObterTodos()
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

        public void Salvar(Receita entidade)
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

        public IList<Receita> ListarReceitasConta(int contaId)
        {
            try
            {
                return _repositorio.ListarReceitasConta(contaId);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
