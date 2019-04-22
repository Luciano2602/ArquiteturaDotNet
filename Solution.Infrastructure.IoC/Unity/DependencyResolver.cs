using Microsoft.EntityFrameworkCore;
using Solution.Domain.Service;
using Solution.Infrastructure.DataAccessObject;
using Unity;
using Unity.Lifetime;

namespace Solution.Infrastructure.IoC
{
    public static class DependencyResolver
    {
        public static void Resolve(UnityContainer container)
        {
            container.RegisterType<DbContext, Context>(new HierarchicalLifetimeManager());
            container.RegisterType<IUnitOfWork, UnitOfWork>(new HierarchicalLifetimeManager());

            container.RegisterType<IUsuarioService, UsuarioService>(new HierarchicalLifetimeManager());

            container.RegisterType(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            container.RegisterType<IUsuarioRepository, UsuarioRepository>(new HierarchicalLifetimeManager());
        }
    }
}
