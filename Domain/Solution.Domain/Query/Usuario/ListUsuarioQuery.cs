using MediatR;
using Solution.Api.ViewModel;
using System.Collections.Generic;

namespace Solution.Domain.Query
{
    public class ListUsuarioQuery : UsuarioBaseQuery, IRequest<IEnumerable<UsuarioViewModel>>
    {
    }
}
