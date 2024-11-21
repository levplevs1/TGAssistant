using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TelegramBot.Application.src.Entities.Type_Of_Requests.Commands.CreateType_Of_Requests;
using TelegramBot.Application.src.Entities.Type_Of_Requests.Commands.DeleteType_Of_Requests;
using TelegramBot.Application.src.Entities.Type_Of_Requests.Commands.UpdateType_Of_Requests;
using TelegramBot.Application.src.Entities.Type_Of_Requests.Queries.GetType_Of_RequestsDetails;
using TelegramBot.Application.src.Entities.Type_Of_Requests.Queries.GetType_Of_RequestsList;
using TelegramBot.Application.src.Entities.Users.Commands.CreateUsers;
using TelegramBot.Application.src.Entities.Users.Commands.DeleteUsers;
using TelegramBot.Application.src.Entities.Users.Commands.UpdateUsers;
using TelegramBot.Application.src.Entities.Users.Queries.GetUsersDetails;
using TelegramBot.Application.src.Entities.Users.Queries.GetUsersList;
using TelegramBot.WebApi.src.EntitiesDto.Type_Of_Requests;
using TelegramBot.WebApi.src.EntitiesDto.UsersDto;

namespace TelegramBot.WebApi.src.Controllers
{
    [Route("api/[controller]")]
    public class Type_Of_RequestsController : BaseController
    {
        private readonly IMapper _mapper;

        public Type_Of_RequestsController(IMapper mapper) => _mapper = mapper;

        [HttpGet]
        public async Task<ActionResult<Type_Of_RequestsListVm>> GetAllType_Of_Requests()
        {
            var query = new GetType_Of_RequestsListQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{id_type_of_requests}")]
        public async Task<ActionResult<Type_Of_RequestsDetailsVm>> GetType_Of_RequestsDetails(int id_type_of_requests)
        {
            var query = new GetType_Of_RequestsDetailsQuery
            {
                id_type_of_requests = id_type_of_requests
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateType_Of_Requests([FromBody] CreateType_Of_RequestsDto createType_Of_RequestsDto)
        {
            var command = _mapper.Map<CreateType_Of_RequestsCommand>(createType_Of_RequestsDto);
            var id_type_of_requests = await Mediator.Send(command);
            return Ok(id_type_of_requests);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateType_Of_Requests([FromBody] UpdateType_Of_RequestsDto updateType_Of_RequestsDto)
        {
            var command = _mapper.Map<UpdateType_Of_RequestsCommand>(updateType_Of_RequestsDto);
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id_type_of_requests}")]
        public async Task<IActionResult> DeleteType_Of_Requests(int id_type_of_requests)
        {
            var command = new DeleteType_Of_RequestsCommand
            {
                id_type_of_requests = id_type_of_requests
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
