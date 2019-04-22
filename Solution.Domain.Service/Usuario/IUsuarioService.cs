using Solution.Api.ViewModel;
using Solution.Domain.Command;
using Solution.Domain.Entity;
using Solution.Domain.Query;
using Solution.Infrastructure.DataAccessObject;
using System;
using System.Collections.Generic;

namespace Solution.Domain.Service
{
    public interface IUsuarioService
    {
        Result Validar(UsuarioStatusCommand command);

        Result Validar(UsuarioInsertCommand command);

        Result Validar(UsuarioUpdateCommand command);

        Result Validar(UsuarioDeleteCommand command);

        bool Existir(UsuarioDomain domain);

        bool Existir(int id);

        UsuarioViewModel ObterPorId(UsuarioQuery query);

        IEnumerable<UsuarioViewModel> ObterTodos();

        UsuarioDomain ToDomain(Usuario entity);

        Usuario ToEntity(UsuarioDomain domain);

        UsuarioViewModel ToViewModel(Usuario usuario);
    }
}