using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Scrutor;
using Solution.Domain.Handler.Command;
using Solution.Domain.Service;
using Solution.Domain.Validator;
using Solution.Infrastructure.DataAccessObject;
using System;

namespace Solution.Api
{
    public static class ServiceCollectionExtensions
    {
        public static void AdicionarInjecaoDependencia(this IServiceCollection services)
        {
            services.AddMediatR(typeof(UsuarioCommandHandler));
            services.AddDbContext<Context>(x => x.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=CadastroUsuario;Trusted_Connection=true;"));
            services.AdicionarClassesComInterfaces(typeof(IUsuarioRepository));
            services.AdicionarClassesComInterfaces(typeof(IUsuarioService));
            services.AdicionarClasses(typeof(UsuarioBaseCommandValidators<>));
        }

        private static void AdicionarClassesComInterfaces(this IServiceCollection services, Type type)
        {
            services.Scan(scan => scan
               .FromAssemblies(type.Assembly)
               .AddClasses()
               .UsingRegistrationStrategy(RegistrationStrategy.Skip)
               .AsMatchingInterface()
               .WithScopedLifetime());
        }

        private static void AdicionarClasses(this IServiceCollection services, Type type)
        {
            services.Scan(scan => scan
               .FromAssemblies(type.Assembly)
               .AddClasses()
               .UsingRegistrationStrategy(RegistrationStrategy.Skip)
               .AsSelf()
               .WithScopedLifetime());
        }
    }
}
