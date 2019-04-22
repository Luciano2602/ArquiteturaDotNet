using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Solution.Api.ViewModel;
using Solution.Domain.Query;
using Solution.Domain.Service;
using Solution.Infrastructure.DataAccessObject;

namespace Solution.Domain.Handler.Query.Usuario
{
    public class UsuarioQueryHandler : IRequestHandler<UsuarioQuery, UsuarioViewModel>,
                                       IRequestHandler<ListUsuarioQuery, IEnumerable<UsuarioViewModel>>
                                       
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IUsuarioService _usuarioService;

        public UsuarioQueryHandler(IUsuarioRepository usuarioRepository, IUsuarioService usuarioService)
        {
            _usuarioRepository = usuarioRepository;
            _usuarioService = usuarioService;
        }

        public async Task<UsuarioViewModel> Handle(UsuarioQuery query, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_usuarioService.ObterPorId(query));
        }

        public async Task<IEnumerable<UsuarioViewModel>> Handle(ListUsuarioQuery query, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_usuarioService.ObterTodos());
        }
    }
}
