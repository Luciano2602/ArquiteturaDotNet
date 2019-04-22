using FluentValidation;
using Solution.Domain.Command;

namespace Solution.Domain.Validator
{
    public class UsuarioStatusCommandValidators : UsuarioBaseCommandValidators<UsuarioStatusCommand>
    {
        public UsuarioStatusCommandValidators()
        {
            RuleFor(command => command.Codigo)
                .GreaterThan(0)
                .WithMessage("O código do usuario deve ser informado");
        }
    }
}
