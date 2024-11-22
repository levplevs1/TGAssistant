using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TelegramBot.Application.src.Entities.Tariffs.Commands.CreateTariffs;
using TelegramBot.Application.src.Entities.Tariffs.Commands.DeleteTariffs;
using TelegramBot.Application.src.Entities.Tariffs.Commands.UpdateTariffs;
using TelegramBot.Application.src.Entities.Tariffs.Queries.GetTariffsDetails;
using TelegramBot.Application.src.Entities.Tariffs.Queries.GetTariffsList;
using TelegramBot.Application.src.Entities.Users.Commands.CreateUsers;
using TelegramBot.Application.src.Entities.Users.Commands.DeleteUsers;
using TelegramBot.Application.src.Entities.Users.Commands.UpdateUsers;
using TelegramBot.Application.src.Entities.Users.Queries.GetUsersDetails;
using TelegramBot.Application.src.Entities.Users.Queries.GetUsersList;
using TelegramBot.WebApi.src.EntitiesDto.Tariffs;
using TelegramBot.WebApi.src.EntitiesDto.UsersDto;

namespace TelegramBot.WebApi.src.Controllers
{
    [Route("api/[controller]")]
    public class TariffsController : BaseController
    {
        private readonly IMapper _mapper;

        public TariffsController(IMapper mapper) => _mapper = mapper;

        [HttpGet]
        public async Task<ActionResult<TariffsListVm>> GetAllTariffs()
        {
            var query = new GetTariffsListQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{id_tariffs}")]
        public async Task<ActionResult<TariffsDetailsVm>> GetTariffsDetails(int id_tariffs)
        {
            var query = new GetTariffsDetailsQuery
            {
                id_tariffs = id_tariffs
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateTariffs([FromBody] CreateTariffsDto createTariffsDto)
        {
            var command = _mapper.Map<CreateTariffsCommand>(createTariffsDto);
            var id_tariffs = await Mediator.Send(command);
            return Ok(id_tariffs);
        }

        [HttpPut("{id_tariffs}")]
        public async Task<IActionResult> UpdateTariffs(int id_tariffs, [FromBody] UpdateTariffsDto updateTariffsDto)
        {
            var command = _mapper.Map<UpdateTariffsCommand>(updateTariffsDto);
            command.id_tariffs = id_tariffs;
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id_tariffs}")]
        public async Task<IActionResult> DeleteTariffs(int id_tariffs)
        {
            var command = new DeleteTariffsCommand
            {
                id_tariffs = id_tariffs
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
