using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TelegramBot.Application.src.Entities.Transport.Commands.CreateTransport;
using TelegramBot.Application.src.Entities.Transport.Commands.DeleteTransport;
using TelegramBot.Application.src.Entities.Transport.Commands.UpdateTransport;
using TelegramBot.Application.src.Entities.Transport.Queries.GetTransportDetails;
using TelegramBot.Application.src.Entities.Transport.Queries.GetTransportList;
using TelegramBot.Application.src.Entities.Users.Commands.CreateUsers;
using TelegramBot.Application.src.Entities.Users.Commands.DeleteUsers;
using TelegramBot.Application.src.Entities.Users.Commands.UpdateUsers;
using TelegramBot.Application.src.Entities.Users.Queries.GetUsersDetails;
using TelegramBot.Application.src.Entities.Users.Queries.GetUsersList;
using TelegramBot.WebApi.src.EntitiesDto.Transport;
using TelegramBot.WebApi.src.EntitiesDto.UsersDto;

namespace TelegramBot.WebApi.src.Controllers
{
    [Route("api/[controller]")]
    public class TransportController : BaseController
    {
        private readonly IMapper _mapper;

        public TransportController(IMapper mapper) => _mapper = mapper;

        [HttpGet]
        public async Task<ActionResult<TransportListVm>> GetAllTransport()
        {
            var query = new GetTransportListQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{id_transport}")]
        public async Task<ActionResult<TransportDetailsVm>> GetTransportDetails(int id_transport)
        {
            var query = new GetTransportDetailsQuery
            {
                id_transport = id_transport
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateTransport([FromBody] CreateTransportDto createTransportDto)
        {
            var command = _mapper.Map<CreateTransportCommand>(createTransportDto);
            var id_transport = await Mediator.Send(command);
            return Ok(id_transport);
        }

        [HttpPut("{id_transport}")]
        public async Task<IActionResult> UpdateTransport(int id_transport, [FromBody] UpdateTransportDto updateTransportDto)
        {
            var command = _mapper.Map<UpdateTransportCommand>(updateTransportDto);
            command.id_transport = id_transport;
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id_transport}")]
        public async Task<IActionResult> DeleteTransport(int id_transport)
        {
            var command = new DeleteTransportCommand
            {
                id_transport = id_transport
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
