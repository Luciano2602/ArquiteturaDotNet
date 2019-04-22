using FluentValidation;
using Solution.Domain.Command;
using System;

namespace Solution.Domain.Validator
{
    public class UsuarioBaseCommandValidators<T> : AbstractValidator<T> where T : UsuarioBaseCommand
    {
        public UsuarioBaseCommandValidators()
        {
            RuleFor(command => command.Nome)
                .NotEmpty()
                .WithMessage("Informe o nome")
                .MaximumLength(20)
                .WithMessage("O nome deve ter no máximo 200 caracteres");

            RuleFor(command => command.SobreNome)
                .NotEmpty()
                .WithMessage("Informe o sobre nome")
                .MaximumLength(20)
                .WithMessage("O sobre nome deve ter no máximo 200 caracteres");

            RuleFor(Command => Command.DataNascimento)
                 .NotEmpty()
                 .WithMessage("A data de nascimento deve ser preenchida")
                 .Must((command, data) =>
                 {
                     return command.DataNascimento <= DateTime.Now;
                 })
                 .WithMessage("A data de nascimento não pode ser maior ou igual a hoje");
        }
    }
}
