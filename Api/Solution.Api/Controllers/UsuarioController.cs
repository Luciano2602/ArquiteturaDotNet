using MediatR;
using Microsoft.AspNetCore.Mvc;
using Solution.Domain.Command;
using Solution.Domain.Query;
using System.Threading.Tasks;

namespace Solution.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsuarioController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> Obter(int id)
        {
            var response = await _mediator.Send(new UsuarioQuery() { Codigo = id });

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodos()
        {
            var response = await _mediator.Send(new ListUsuarioQuery());

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Adicionar(UsuarioInsertCommand command)
        {
            var response = await _mediator.Send(command);

            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Alterar(int id, [FromBody] UsuarioUpdateCommand command)
        {
            command.Codigo = id;
            var response = await _mediator.Send(command);

            return Ok(response);
        }

        [HttpPut("{id}/status")]
        public async Task<IActionResult> AlterarStatus(int id, [FromBody] UsuarioStatusCommand command)
        {
            command.Codigo = id;
            var response = await _mediator.Send(command);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, [FromBody] UsuarioDeleteCommand command)
        {
            command.Codigo = id;
            var response = await _mediator.Send(command);

            return Ok(response);
        }
    }
}
