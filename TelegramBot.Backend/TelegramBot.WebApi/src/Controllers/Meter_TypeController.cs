using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TelegramBot.Application.src.Entities.Meter_Type.Commands.CreateMeter_Type;
using TelegramBot.Application.src.Entities.Meter_Type.Commands.DeleteMeter_Type;
using TelegramBot.Application.src.Entities.Meter_Type.Commands.UpdateMeter_Type;
using TelegramBot.Application.src.Entities.Meter_Type.Queries.GetMeter_TypeDetails;
using TelegramBot.Application.src.Entities.Meter_Type.Queries.GetMeter_TypeList;
using TelegramBot.Application.src.Entities.Users.Commands.CreateUsers;
using TelegramBot.Application.src.Entities.Users.Commands.DeleteUsers;
using TelegramBot.Application.src.Entities.Users.Commands.UpdateUsers;
using TelegramBot.Application.src.Entities.Users.Queries.GetUsersDetails;
using TelegramBot.Application.src.Entities.Users.Queries.GetUsersList;
using TelegramBot.WebApi.src.EntitiesDto.Meter_Type;
using TelegramBot.WebApi.src.EntitiesDto.UsersDto;

namespace TelegramBot.WebApi.src.Controllers
{
    [Route("api/[controller]")]
    public class Meter_TypeController : BaseController
    {
        private readonly IMapper _mapper;

        public Meter_TypeController(IMapper mapper) => _mapper = mapper;

        [HttpGet]
        public async Task<ActionResult<Meter_TypeListVm>> GetAllMeter_Type()
        {
            var query = new GetMeter_TypeListQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{id_meter_type}")]
        public async Task<ActionResult<Meter_TypeDetailsVm>> GetMeter_TypeDetails(int id_meter_type)
        {
            var query = new GetMeter_TypeDetailsQuery
            {
                id_meter_type = id_meter_type
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateMeter_Type([FromBody] CreateMeter_TypeDto createMeter_TypeDto)
        {
            var command = _mapper.Map<CreateMeter_TypeCommand>(createMeter_TypeDto);
            var id_meter_type = await Mediator.Send(command);
            return Ok(id_meter_type);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMeter_Type([FromBody] UpdateMeter_TypeDto updateMeter_TypeDto)
        {
            var command = _mapper.Map<UpdateMeter_TypeCommand>(updateMeter_TypeDto);
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id_meter_type}")]
        public async Task<IActionResult> DeleteMeter_Type(int id_meter_type)
        {
            var command = new DeleteMeter_TypeCommand
            {
                id_meter_type = id_meter_type
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
