using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TelegramBot.Application.src.Entities.Meters.Commands.CreateMeters;
using TelegramBot.Application.src.Entities.Meters.Commands.DeleteMeters;
using TelegramBot.Application.src.Entities.Meters.Commands.UpdateMeters;
using TelegramBot.Application.src.Entities.Meters.Queries.GetMetersDetails;
using TelegramBot.Application.src.Entities.Meters.Queries.GetMetersList;
using TelegramBot.Application.src.Entities.Users.Commands.CreateUsers;
using TelegramBot.Application.src.Entities.Users.Commands.DeleteUsers;
using TelegramBot.Application.src.Entities.Users.Commands.UpdateUsers;
using TelegramBot.Application.src.Entities.Users.Queries.GetUsersDetails;
using TelegramBot.Application.src.Entities.Users.Queries.GetUsersList;
using TelegramBot.WebApi.src.EntitiesDto.Meters;
using TelegramBot.WebApi.src.EntitiesDto.UsersDto;

namespace TelegramBot.WebApi.src.Controllers
{
    [Route("api/[controller]")]
    public class MetersController : BaseController
    {
        private readonly IMapper _mapper;

        public MetersController(IMapper mapper) => _mapper = mapper;

        [HttpGet]
        public async Task<ActionResult<MetersListVm>> GetAllMeters()
        {
            var query = new GetMetersListQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{id_meters}")]
        public async Task<ActionResult<MetersDetailsVm>> GetMetersDetails(int id_meters)
        {
            var query = new GetMetersDetailsQuery
            {
                id_meters = id_meters
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateMeters([FromBody] CreateMetersDto createMetersDto)
        {
            var command = _mapper.Map<CreateMetersCommand>(createMetersDto);
            var id_meters = await Mediator.Send(command);
            return Ok(id_meters);
        }

        [HttpPut("{id_meters}")]
        public async Task<IActionResult> UpdateMeters(int id_meters, [FromBody] UpdateMetersDto updateMetersDto)
        {
            var command = _mapper.Map<UpdateMetersCommand>(updateMetersDto);
            command.id_meters = id_meters;
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id_meters}")]
        public async Task<IActionResult> DeleteMeters(int id_meters)
        {
            var command = new DeleteMetersCommand
            {
                id_meters = id_meters
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
