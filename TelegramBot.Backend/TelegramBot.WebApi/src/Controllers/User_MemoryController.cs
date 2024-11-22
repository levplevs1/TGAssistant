using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TelegramBot.Application.src.Entities.User_Memory.Commands.CreateUser_Memory;
using TelegramBot.Application.src.Entities.User_Memory.Commands.DeleteUser_Memory;
using TelegramBot.Application.src.Entities.User_Memory.Commands.UpdateUser_Memory;
using TelegramBot.Application.src.Entities.User_Memory.Queries.GetUser_MemoryDetails;
using TelegramBot.Application.src.Entities.User_Memory.Queries.GetUser_MemoryList;
using TelegramBot.Application.src.Entities.Users.Commands.CreateUsers;
using TelegramBot.Application.src.Entities.Users.Commands.DeleteUsers;
using TelegramBot.Application.src.Entities.Users.Commands.UpdateUsers;
using TelegramBot.Application.src.Entities.Users.Queries.GetUsersDetails;
using TelegramBot.Application.src.Entities.Users.Queries.GetUsersList;
using TelegramBot.WebApi.src.EntitiesDto.User_Memory;
using TelegramBot.WebApi.src.EntitiesDto.UsersDto;

namespace TelegramBot.WebApi.src.Controllers
{
    [Route("api/[controller]")]
    public class User_MemoryController : BaseController
    {
        private readonly IMapper _mapper;

        public User_MemoryController(IMapper mapper) => _mapper = mapper;

        [HttpGet]
        public async Task<ActionResult<User_MemoryListVm>> GetAllUser_Memory()
        {
            var query = new GetUser_MemoryListQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{id_user_memory}")]
        public async Task<ActionResult<User_MemoryDetailsVm>> GetUser_MemoryDetails(int id_user_memory)
        {
            var query = new GetUser_MemoryDetailsQuery
            {
                id_user_memory = id_user_memory
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateUser_Memory([FromBody] CreateUser_MemoryDto createUser_MemoryDto)
        {
            var command = _mapper.Map<CreateUser_MemoryCommand>(createUser_MemoryDto);
            var id_user_memory = await Mediator.Send(command);
            return Ok(id_user_memory);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser_Memory([FromBody] UpdateUser_MemoryDto updateUser_MemoryDto)
        {
            var command = _mapper.Map<UpdateUser_MemoryCommand>(updateUser_MemoryDto);
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id_user_memory}")]
        public async Task<IActionResult> DeleteUser_Memory(int id_user_memory)
        {
            var command = new DeleteUser_MemoryCommand
            {
                id_user_memory = id_user_memory
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
