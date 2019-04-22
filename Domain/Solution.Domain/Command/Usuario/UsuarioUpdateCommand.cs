using MediatR;
using Solution.Infrastructure.DataAccessObject;

namespace Solution.Domain.Command
{
    public class UsuarioUpdateCommand : UsuarioBaseCommand, IRequest<Result>
    {
        public int Codigo { get; set; }
    }
}
