using MediatR;
using Solution.Api.ViewModel;

namespace Solution.Domain.Query
{
    public class UsuarioQuery : UsuarioBaseQuery, IRequest<UsuarioViewModel>
    {
    }
}
