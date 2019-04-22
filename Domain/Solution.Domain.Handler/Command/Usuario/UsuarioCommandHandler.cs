using FluentValidation.Results;
using MediatR;
using Solution.Domain.Command;
using Solution.Domain.Factory;
using Solution.Domain.Service;
using Solution.Domain.Validator;
using Solution.Infrastructure.DataAccessObject;
using System.Threading;
using System.Threading.Tasks;

namespace Solution.Domain.Handler.Command
{
    public class UsuarioCommandHandler : IRequestHandler<UsuarioInsertCommand, Result>,
                                         IRequestHandler<UsuarioUpdateCommand, Result>,
                                         IRequestHandler<UsuarioDeleteCommand, Result>,
                                         IRequestHandler<UsuarioStatusCommand, Result>
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UsuarioCommandHandler(IUsuarioService usuarioService, IUsuarioRepository usuarioRepository, IUnitOfWork unitOfWork)
        {
            _usuarioService = usuarioService;
            _usuarioRepository = usuarioRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(UsuarioInsertCommand command, CancellationToken cancellationToken)
        {
            var result = _usuarioService.Validar(command);

            if (!result.Valido) { return await Task.FromResult(result); }

            var domain = UsuarioFactory.Criar(command);
            domain.Criar();
            
            _usuarioRepository.Adicionar(_usuarioService.ToEntity(domain));
            _unitOfWork.SaveChanges();

            return await Task.FromResult(result);
        }

        public async Task<Result> Handle(UsuarioUpdateCommand command, CancellationToken cancellationToken)
        {
            var result = _usuarioService.Validar(command);

            if (!result.Valido) { return await Task.FromResult(result); }

            var domain = UsuarioFactory.Alterar(command);

            _usuarioRepository.Alterar(_usuarioService.ToEntity(domain));
            _unitOfWork.SaveChanges();

            return await Task.FromResult(result);
        }

        public async Task<Result> Handle(UsuarioDeleteCommand command, CancellationToken cancellationToken)
        {
            var result = _usuarioService.Validar(command);

            if (!result.Valido) { return await Task.FromResult(result); }

            var domain = UsuarioFactory.Excluir(command);
            domain.Excluir();

            _usuarioRepository.Alterar(_usuarioService.ToEntity(domain));
            _unitOfWork.SaveChanges();

            return await Task.FromResult(result);
        }

        public async Task<Result> Handle(UsuarioStatusCommand command, CancellationToken cancellationToken)
        {
            var result = _usuarioService.Validar(command);

            if (!result.Valido) { return await Task.FromResult(result); }

            var domain = UsuarioFactory.Status(command);

            _usuarioRepository.Alterar(_usuarioService.ToEntity(domain));
            _unitOfWork.SaveChanges();

            return await Task.FromResult(result);
        }
    }
}
