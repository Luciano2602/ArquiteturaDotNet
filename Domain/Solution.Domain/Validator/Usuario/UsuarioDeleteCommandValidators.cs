using FluentValidation;
using Solution.Domain.Command;

namespace Solution.Domain.Validator
{
    public class UsuarioDeleteCommandValidators : UsuarioBaseCommandValidators<UsuarioDeleteCommand>
    {
        public UsuarioDeleteCommandValidators()
        {
            RuleFor(command => command.Codigo)
                .Empty()
                .WithMessage("O código do usuario deve ser informado");
        }
    }
}
