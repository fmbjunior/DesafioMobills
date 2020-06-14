using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioMobills.WebApi.Negocio.Interface
{
    public interface INegocio<T> where T : class
    {
        void Salvar(T entidade);
        IList<T> ObterTodos();
        T ObterPorId(int id);
        void Excluir(int id);
    }
}
