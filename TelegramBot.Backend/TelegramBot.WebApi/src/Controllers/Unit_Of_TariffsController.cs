using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TelegramBot.Application.src.Entities.Unit_Of_Tariffs.Commands.CreateUnit_Of_Tariffs;
using TelegramBot.Application.src.Entities.Unit_Of_Tariffs.Commands.DeleteUnit_Of_Tariffs;
using TelegramBot.Application.src.Entities.Unit_Of_Tariffs.Commands.UpdateUnit_Of_Tariffs;
using TelegramBot.Application.src.Entities.Unit_Of_Tariffs.Queries.GetUnit_Of_TariffsDetails;
using TelegramBot.Application.src.Entities.Unit_Of_Tariffs.Queries.GetUnit_Of_TariffsList;
using TelegramBot.Application.src.Entities.Users.Commands.CreateUsers;
using TelegramBot.Application.src.Entities.Users.Commands.DeleteUsers;
using TelegramBot.Application.src.Entities.Users.Queries.GetUsersDetails;
using TelegramBot.Application.src.Entities.Users.Queries.GetUsersList;
using TelegramBot.WebApi.src.EntitiesDto.Unit_Of_Tariffs;
using TelegramBot.WebApi.src.EntitiesDto.UsersDto;

namespace TelegramBot.WebApi.src.Controllers
{
    [Route("api/[controller]")]
    public class Unit_Of_TariffsController : BaseController
    {
        private readonly IMapper _mapper;

        public Unit_Of_TariffsController(IMapper mapper) => _mapper = mapper;

        [HttpGet]
        public async Task<ActionResult<Unit_Of_TariffsListVm>> GetAllUnit_Of_Tariffs()
        {
            var query = new GetUnit_Of_TariffsListQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{id_unit_of_tariffs}")]
        public async Task<ActionResult<Unit_Of_TariffsDetailsVm>> GetUnit_Of_TariffsDetails(int id_unit_of_tariffs)
        {
            var query = new GetUnit_Of_TariffsDetailsQuery
            {
                id_unit_of_tariffs = id_unit_of_tariffs
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateUnit_Of_Tariffs([FromBody] CreateUnit_Of_TariffsDto createUnit_Of_TariffsDto)
        {
            var command = _mapper.Map<CreateUnit_Of_TariffsCommand>(createUnit_Of_TariffsDto);
            var id_unit_of_tariffs = await Mediator.Send(command);
            return Ok(id_unit_of_tariffs);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUnit_Of_Tariffs([FromBody] UpdateUnit_Of_TariffsDto updateUnit_Of_TariffsDto)
        {
            var command = _mapper.Map<UpdateUnit_Of_TariffsCommand>(updateUnit_Of_TariffsDto);
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id_unit_of_tariffs}")]
        public async Task<IActionResult> DeleteUnit_Of_Tariffs(int id_unit_of_tariffs)
        {
            var command = new DeleteUnit_Of_TariffsCommand
            {
                id_unit_of_tariffs = id_unit_of_tariffs
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
