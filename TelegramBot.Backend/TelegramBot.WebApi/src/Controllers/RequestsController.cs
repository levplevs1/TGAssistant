using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TelegramBot.Application.src.Entities.Requests.Commands.CreateRequest;
using TelegramBot.Application.src.Entities.Requests.Commands.DeleteRequests;
using TelegramBot.Application.src.Entities.Requests.Commands.UpdateRequests;
using TelegramBot.Application.src.Entities.Requests.Queries.GetRequestList;
using TelegramBot.Application.src.Entities.Requests.Queries.GetRequestsDetails;
using TelegramBot.Application.src.Entities.Requests.Queries.GetRequestsList;
using TelegramBot.Application.src.Entities.Users.Commands.CreateUsers;
using TelegramBot.Application.src.Entities.Users.Commands.DeleteUsers;
using TelegramBot.Application.src.Entities.Users.Commands.UpdateUsers;
using TelegramBot.Application.src.Entities.Users.Queries.GetUsersDetails;
using TelegramBot.Application.src.Entities.Users.Queries.GetUsersList;
using TelegramBot.WebApi.src.EntitiesDto.Requests;
using TelegramBot.WebApi.src.EntitiesDto.UsersDto;

namespace TelegramBot.WebApi.src.Controllers
{
    [Route("api/[controller]")]
    public class RequestsController : BaseController
    {
        private readonly IMapper _mapper;

        public RequestsController(IMapper mapper) => _mapper = mapper;

        [HttpGet]
        public async Task<ActionResult<RequestsListVm>> GetAllRequests()
        {
            var query = new GetRequestsListQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{id_requests}")]
        public async Task<ActionResult<RequestsDetailsVm>> GetRequestsDetails(int id_requests)
        {
            var query = new GetRequestsDetailsQuery
            {
                id_requests = id_requests
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateRequests([FromBody] CreateRequestsDto createRequestsDto)
        {
            var command = _mapper.Map<CreateRequestsCommand>(createRequestsDto);
            var id_requests = await Mediator.Send(command);
            return Ok(id_requests);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateRequests([FromBody] UpdateRequestsDto updateRequestsDto)
        {
            var command = _mapper.Map<UpdateRequestsCommand>(updateRequestsDto);
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id_requests}")]
        public async Task<IActionResult> DeleteRequests(int id_requests)
        {
            var command = new DeleteRequestsCommand
            {
                id_requests = id_requests
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
