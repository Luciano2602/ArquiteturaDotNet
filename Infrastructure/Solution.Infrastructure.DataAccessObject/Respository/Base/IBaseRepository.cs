using System;
using System.Collections.Generic;
using System.Linq;

namespace Solution.Infrastructure.DataAccessObject
{
    public interface IBaseRepository<T> where T: class
    {
        IEnumerable<T> ObterTodos();

        IEnumerable<T> Obter(Func<T, bool> filtro);

        T ObterPorId(params object[] id);

        bool Existir(Func<T, bool> filtro);

        void Alterar(T obj);

        void AlterarTodos(IList<T> obj);

        void Adicionar(T obj);

        void AdicionarTodos(IList<T> obj);

        void ExcluirTodos(Func<T, bool> filtro);

        void Excluir(T obj);
    }
}
