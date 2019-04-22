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
        private readonly Context _context;
        private readonly UsuarioRepository _usuarioRepository;
        private readonly UsuarioService _usuarioService;

        public UsuarioQueryHandler()
        {
            _context = new Context();
            //_usuarioService = new UsuarioService(_context);
            _usuarioRepository = new UsuarioRepository(_context);
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
