using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioMobills.WebApi.Repositorio.Interface
{
    public interface IRepositorio<T> where T : class
    {
        void Adicionar(T entidade);
        IList<T> ObterTodos();
        T ObterPorId(int id);
        void Atualizar(T entidade);
        void Excluir(int id);
    }
}
