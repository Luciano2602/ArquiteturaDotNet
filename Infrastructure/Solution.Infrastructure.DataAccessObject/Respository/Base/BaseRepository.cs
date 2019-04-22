using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Solution.Infrastructure.DataAccessObject
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly Context _context;

        public BaseRepository(Context context)
        {
            _context = context;
        }

        public void Adicionar(T obj) => _context.Set<T>().Add(obj);

        public void AdicionarTodos(IList<T> obj) => _context.Set<T>().AddRange(obj);

        public void Alterar(T obj) => _context.Set<T>().Update(obj);

        public void AlterarTodos(IList<T> obj) => _context.Set<T>().UpdateRange(obj);

        public void ExcluirTodos(Func<T, bool> filtros) => _context.Set<T>().RemoveRange(_context.Set<T>().Where(filtros));

        public void Excluir(T obj) => _context.Set<T>().Remove(obj);

        public bool Existir(Func<T, bool> filtros)
        {
            DetectarCarrefamentoPreguicoso(false);
            return _context.Set<T>().Where(filtros).Any();
        }

        public IEnumerable<T> Obter(Func<T, bool> filtros)
        {
            DetectarCarrefamentoPreguicoso(false);
            return _context.Set<T>().Where(filtros).ToList();
        }

        public T ObterPorId(params object[] id)
        {
            DetectarCarrefamentoPreguicoso(false);
            return _context.Set<T>().Find(id);
        }

        public IEnumerable<T> ObterTodos()
        {
            DetectarCarrefamentoPreguicoso(false);
            return _context.Set<T>().ToList();
        }

        public void DetectarCarrefamentoPreguicoso(bool enabled)
        {
            _context.ChangeTracker.AutoDetectChangesEnabled = enabled;
            _context.ChangeTracker.LazyLoadingEnabled = enabled;
            _context.ChangeTracker.QueryTrackingBehavior = enabled ? QueryTrackingBehavior.TrackAll : QueryTrackingBehavior.NoTracking;
        }
    }
}