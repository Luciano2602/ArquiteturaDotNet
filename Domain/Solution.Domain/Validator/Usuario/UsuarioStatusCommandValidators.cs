using FluentValidation;
using Solution.Domain.Command;

namespace Solution.Domain.Validator
{
    public class UsuarioStatusCommandValidators : UsuarioBaseCommandValidators<UsuarioStatusCommand>
    {
        public UsuarioStatusCommandValidators()
        {
            RuleFor(command => command.Codigo)
                .Empty()
                .WithMessage("O código do usuario deve ser informado");
        }
    }
}
