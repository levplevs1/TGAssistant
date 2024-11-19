using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TelegramBot.Application.src.Entities.Users.Commands.CreateUsers;
using TelegramBot.Application.src.Entities.Users.Commands.DeleteUsers;
using TelegramBot.Application.src.Entities.Users.Commands.UpdateUsers;
using TelegramBot.Application.src.Entities.Users.Queries.GetUsersDetails;
using TelegramBot.Application.src.Entities.Users.Queries.GetUsersList;
using TelegramBot.WebApi.src.EntitiesDto.UsersDto;

namespace TelegramBot.WebApi.src.Controllers
{
    [Route("api/[controller]")]
    public class UserController : BaseController
    {
        private readonly IMapper _mapper;

        public UserController(IMapper mapper) => _mapper = mapper;

        [HttpGet]
        public async Task<ActionResult<UsersListVm>> GetAllUsers()
        {
            var query = new GetUsersListQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{id_users}")]
        public async Task<ActionResult<UsersDetailsVm>> GetUsersDetails(int id_users)
        {
            var query = new GetUsersDetailsQuery
            {
                id_users = id_users
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateUsers([FromBody] CreateUsersDto createUsersDto)
        {
            var command = _mapper.Map<CreateUsersCommand>(createUsersDto);
            var id_users = await Mediator.Send(command);
            return Ok(id_users);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUsers([FromBody] UpdateUsersDto updateUsersDto)
        {
            var command = _mapper.Map<UpdateUsersCommand>(updateUsersDto);
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id_users}")]
        public async Task<IActionResult> DeleteUsers(int id_users)
        {
            var command = new DeleteUsersCommand
            {
                id_users = id_users
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
