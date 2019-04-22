using MediatR;
using Solution.Infrastructure.DataAccessObject;

namespace Solution.Domain.Command
{
    public class UsuarioStatusCommand : UsuarioBaseCommand, IRequest<Result>
    {
        public int Codigo { get; set; }
    }
}
