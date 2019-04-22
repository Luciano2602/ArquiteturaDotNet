using MediatR;
using Solution.Infrastructure.DataAccessObject;

namespace Solution.Domain.Command
{
    public class UsuarioInsertCommand : UsuarioBaseCommand, IRequest<Result>
    {
    }
}
