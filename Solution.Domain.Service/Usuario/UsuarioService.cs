using FluentValidation.Results;
using Solution.Api.ViewModel;
using Solution.Domain.Command;
using Solution.Domain.Entity;
using Solution.Domain.Query;
using Solution.Domain.Validator;
using Solution.Domain.ValueObject;
using Solution.Infrastructure.DataAccessObject;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Solution.Domain.Service
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly Result _result;
        private readonly UsuarioStatusCommandValidators _usuarioStatusCommandValidators;
        private readonly UsuarioInsertCommandValidators _usuarioInsertCommandValidators;
        private readonly UsuarioUpdateCommandValidators _usuarioUpdateCommandValidators;
        private readonly UsuarioDeleteCommandValidators _usuarioDeleteCommandValidators;

        public UsuarioService(
            IUsuarioRepository usuarioRepository,
            UsuarioStatusCommandValidators usuarioStatusCommandValidators,
            UsuarioInsertCommandValidators usuarioInsertCommandValidators,
            UsuarioUpdateCommandValidators usuarioUpdateCommandValidators,
            UsuarioDeleteCommandValidators usuarioDeleteCommandValidators
            )
        {
            _usuarioRepository = usuarioRepository;
            _usuarioStatusCommandValidators = usuarioStatusCommandValidators;
            _usuarioInsertCommandValidators = usuarioInsertCommandValidators;
            _usuarioUpdateCommandValidators = usuarioUpdateCommandValidators;
            _usuarioDeleteCommandValidators = usuarioDeleteCommandValidators;
            _result = new Result();
        }

        #region Validacao
        public Result Validar(UsuarioStatusCommand command)
        {
            ValidationResult results = _usuarioStatusCommandValidators.Validate(command);

            if (!results.IsValid) 
            {
                _result.Invalidar();
                _result.AdicionarMensagem(results.Errors);
            }

            if (!Existir(command.Codigo))
            {
                _result.Invalidar();
                _result.AdicionarMensagem("Banco", "Usuario não encontrado");
            }

            if(_result.Valido)
            {
                _result.AdicionarMensagem("Suceeso", "Comando executado com sucesso");
            }

            _result.AdicionarObjeto(command);

            return _result;
        }

        public Result Validar(UsuarioInsertCommand command)
        {
            ValidationResult results = _usuarioInsertCommandValidators.Validate(command);

            if (!results.IsValid)
            {
                _result.Invalidar();
                _result.AdicionarMensagem(results.Errors);
            }
            
            if (_result.Valido)
            {
                _result.AdicionarMensagem("Suceeso", "Comando executado com sucesso");
            }

            _result.AdicionarObjeto(command);

            return _result;
        }
        
        public Result Validar(UsuarioUpdateCommand command)
        {
            ValidationResult results = _usuarioUpdateCommandValidators.Validate(command);

            if (!results.IsValid)
            {
                _result.Invalidar();
                _result.AdicionarMensagem(results.Errors);
            }

            if (!Existir(command.Codigo))
            {
                _result.Invalidar();
                _result.AdicionarMensagem("Banco", "Usuario não encontrado");
            }

            if (_result.Valido)
            {
                _result.AdicionarMensagem("Suceeso", "Comando executado com sucesso");
            }

            _result.AdicionarObjeto(command);

            return _result;
        }

        public Result Validar(UsuarioDeleteCommand command)
        {
            ValidationResult results = _usuarioDeleteCommandValidators.Validate(command);

            if (!results.IsValid)
            {
                _result.Invalidar();
                _result.AdicionarMensagem(results.Errors);
            }

            if (!Existir(command.Codigo))
            {
                _result.Invalidar();
                _result.AdicionarMensagem("Banco", "Usuario não encontrado");
            }

            if (_result.Valido)
            {
                _result.AdicionarMensagem("Suceeso", "Comando executado com sucesso");
            }

            _result.AdicionarObjeto(command);

            return _result;
        }
        #endregion

        #region Repositorio
        public bool Existir(UsuarioDomain domain)
        {
            return _usuarioRepository.Existir(x => x.DataNascimento == domain.DataNascimento && x.Nome == domain.NomeCompleto.Nome && x.Sobrenome == domain.NomeCompleto.Sobrenome);
        }

        public bool Existir(int id)
        {
            return _usuarioRepository.Existir(x => x.Codigo == id);
        }

        public UsuarioViewModel ObterPorId(UsuarioQuery query)
        {
            return ToViewModel(_usuarioRepository.ObterPorId(query.Codigo));
        }

        public IEnumerable<UsuarioViewModel> ObterTodos()
        {
            return _usuarioRepository.ObterTodos().Select(ToViewModel);
        }

        
        #endregion

        #region Mapeamento
        public Func<Usuario, UsuarioDomain> Domain => data => new UsuarioDomain(data.Codigo, new NomeCompleto(data.Nome, data.Sobrenome), data.DataNascimento, data.Status) { };

        public Func<UsuarioDomain, Usuario> Entity => data => new Usuario()
        {
            Codigo = data.Codigo,
            DataNascimento = data.DataNascimento,
            Nome = data.NomeCompleto.Nome,
            Sobrenome = data.NomeCompleto.Sobrenome,
            Status = data.Status
        };

        public Func<Usuario, UsuarioViewModel> ViewModel => data => new UsuarioViewModel()
        {
            Codigo = data.Codigo,
            DataNascimento = data.DataNascimento,
            Nome = data.Nome,
            Sobrenome = data.Sobrenome,
            Status = data.Status
        };
        #endregion

        public UsuarioDomain ToDomain(Usuario entity) => Domain(entity);

        public Usuario ToEntity(UsuarioDomain domain) => Entity(domain);

        public UsuarioViewModel ToViewModel(Usuario usuario) => ViewModel(usuario);

    }
}