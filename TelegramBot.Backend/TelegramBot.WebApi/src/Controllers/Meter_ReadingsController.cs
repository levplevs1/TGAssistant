using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TelegramBot.Application.src.Entities.Meter_Readings.Commands.CreateMeter_Readings;
using TelegramBot.Application.src.Entities.Meter_Readings.Commands.DeleteMeter_Readings;
using TelegramBot.Application.src.Entities.Meter_Readings.Commands.UpdateMeter_Readings;
using TelegramBot.Application.src.Entities.Meter_Readings.Queries.GetMeter_ReadingsDetails;
using TelegramBot.Application.src.Entities.Meter_Readings.Queries.GetMeter_ReadingsList;
using TelegramBot.Application.src.Entities.Users.Commands.CreateUsers;
using TelegramBot.Application.src.Entities.Users.Commands.DeleteUsers;
using TelegramBot.Application.src.Entities.Users.Commands.UpdateUsers;
using TelegramBot.Application.src.Entities.Users.Queries.GetUsersDetails;
using TelegramBot.Application.src.Entities.Users.Queries.GetUsersList;
using TelegramBot.WebApi.src.EntitiesDto.Meter_Readings;
using TelegramBot.WebApi.src.EntitiesDto.UsersDto;

namespace TelegramBot.WebApi.src.Controllers
{
    [Route("api/[controller]")]
    public class Meter_ReadingsController : BaseController
    {
        private readonly IMapper _mapper;

        public Meter_ReadingsController(IMapper mapper) => _mapper = mapper;

        [HttpGet]
        public async Task<ActionResult<Meter_ReadingsListVm>> GetAllMeter_Readings()
        {
            var query = new GetMeter_ReadingsListQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{id_meter_readings}")]
        public async Task<ActionResult<Meter_ReadingsDetailsVm>> GetMeter_ReadingsDetails(int id_meter_readings)
        {
            var query = new GetMeter_ReadingsDetailsQuery
            {
                id_meter_readings = id_meter_readings
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateMeter_Readings([FromBody] CreateMeter_ReadingsDto createMeter_ReadingsDto)
        {
            var command = _mapper.Map<CreateMeter_ReadingsCommand>(createMeter_ReadingsDto);
            var id_meter_readings = await Mediator.Send(command);
            return Ok(id_meter_readings);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMeter_Readings([FromBody] UpdateMeter_ReadingsDto updateMeter_ReadingsDto)
        {
            var command = _mapper.Map<UpdateMeter_ReadingsCommand>(updateMeter_ReadingsDto);
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id_meter_readings}")]
        public async Task<IActionResult> DeleteMeter_Readings(int id_meter_readings)
        {
            var command = new DeleteMeter_ReadingsCommand
            {
                id_meter_readings = id_meter_readings
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
