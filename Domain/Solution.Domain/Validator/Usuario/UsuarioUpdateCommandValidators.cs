using FluentValidation;
using Solution.Domain.Command;

namespace Solution.Domain.Validator
{
    public class UsuarioUpdateCommandValidators : UsuarioBaseCommandValidators<UsuarioUpdateCommand>
    {
        public UsuarioUpdateCommandValidators()
        {
            RuleFor(command => command.Codigo)
                .GreaterThan(0)
                .WithMessage("O código do usuario deve ser informado");
        }
    }
}
