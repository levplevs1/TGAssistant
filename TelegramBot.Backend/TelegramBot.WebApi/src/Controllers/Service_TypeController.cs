using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TelegramBot.Application.src.Entities.Service_Type.Commands.CreateService_Type;
using TelegramBot.Application.src.Entities.Service_Type.Commands.DeleteService_Type;
using TelegramBot.Application.src.Entities.Service_Type.Commands.UpdateService_Type;
using TelegramBot.Application.src.Entities.Service_Type.Queries.GetService_TypeDetails;
using TelegramBot.Application.src.Entities.Service_Type.Queries.GetService_TypeList;
using TelegramBot.Application.src.Entities.Users.Commands.CreateUsers;
using TelegramBot.Application.src.Entities.Users.Commands.DeleteUsers;
using TelegramBot.Application.src.Entities.Users.Commands.UpdateUsers;
using TelegramBot.Application.src.Entities.Users.Queries.GetUsersDetails;
using TelegramBot.Application.src.Entities.Users.Queries.GetUsersList;
using TelegramBot.WebApi.src.EntitiesDto.Service_Type;
using TelegramBot.WebApi.src.EntitiesDto.UsersDto;

namespace TelegramBot.WebApi.src.Controllers
{
    [Route("api/[controller]")]
    public class Service_TypeController : BaseController
    {
        private readonly IMapper _mapper;

        public Service_TypeController(IMapper mapper) => _mapper = mapper;

        [HttpGet]
        public async Task<ActionResult<Service_TypeListVm>> GetAllService_Type()
        {
            var query = new GetService_TypeListQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{id_service_type}")]
        public async Task<ActionResult<Service_TypeDetailsVm>> GetService_TypeDetails(int id_service_type)
        {
            var query = new GetService_TypeDetailsQuery
            {
                id_service_type = id_service_type
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateService_Type([FromBody] CreateService_TypeDto createService_TypeDto)
        {
            var command = _mapper.Map<CreateService_TypeCommand>(createService_TypeDto);
            var id_service_type = await Mediator.Send(command);
            return Ok(id_service_type);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateService_Type([FromBody] UpdateService_TypeDto updateService_TypeDto)
        {
            var command = _mapper.Map<UpdateService_TypeCommand>(updateService_TypeDto);
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id_service_type}")]
        public async Task<IActionResult> DeleteService_Type(int id_service_type)
        {
            var command = new DeleteService_TypeCommand
            {
                id_service_type = id_service_type
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
