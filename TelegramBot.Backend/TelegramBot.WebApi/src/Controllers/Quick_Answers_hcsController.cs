using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TelegramBot.Application.src.Entities.Quick_Answers_hcs.Commands.CreateQuick_Answers_hcs;
using TelegramBot.Application.src.Entities.Quick_Answers_hcs.Commands.DeleteQuick_Answers_hcs;
using TelegramBot.Application.src.Entities.Quick_Answers_hcs.Commands.UpdateQuick_Answers_hcs;
using TelegramBot.Application.src.Entities.Quick_Answers_hcs.Queries.GetQuick_Answers_hcsDetails;
using TelegramBot.Application.src.Entities.Quick_Answers_hcs.Queries.GetQuick_Answers_hcsList;
using TelegramBot.Application.src.Entities.Users.Commands.CreateUsers;
using TelegramBot.Application.src.Entities.Users.Commands.DeleteUsers;
using TelegramBot.Application.src.Entities.Users.Commands.UpdateUsers;
using TelegramBot.Application.src.Entities.Users.Queries.GetUsersDetails;
using TelegramBot.Application.src.Entities.Users.Queries.GetUsersList;
using TelegramBot.WebApi.src.EntitiesDto.Quick_Answers_hcs;
using TelegramBot.WebApi.src.EntitiesDto.UsersDto;

namespace TelegramBot.WebApi.src.Controllers
{
    [Route("api/[controller]")]
    public class Quick_Answers_hcsController : BaseController
    {
        private readonly IMapper _mapper;

        public Quick_Answers_hcsController(IMapper mapper) => _mapper = mapper;

        [HttpGet]
        public async Task<ActionResult<Quick_Answers_hcsListVm>> GetAllQuick_Answers_hcs()
        {
            var query = new GetQuick_Answers_hcsListQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{id_quick_answers_hcs}")]
        public async Task<ActionResult<Quick_Answers_hcsDetailsVm>> GetQuick_Answers_hcsDetails(int id_quick_answers_hcs)
        {
            var query = new GetQuick_Answers_hcsDetailsQuery
            {
                id_quick_answers_hcs = id_quick_answers_hcs
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateQuick_Answers_hcs([FromBody] CreateQuick_Answers_hcsDto createQuick_Answers_hcsDto)
        {
            var command = _mapper.Map<CreateQuick_Answers_hcsCommand>(createQuick_Answers_hcsDto);
            var id_quick_answers_hcs = await Mediator.Send(command);
            return Ok(id_quick_answers_hcs);
        }

        [HttpPut("{id_quick_answers_hcs}")]
        public async Task<IActionResult> UpdateQuick_Answers_hcs(int id_quick_answers_hcs, [FromBody] UpdateQuick_Answers_hcsDto updateQuick_Answers_hcsDto)
        {
            var command = _mapper.Map<UpdateQuick_Answers_hcsCommand>(updateQuick_Answers_hcsDto);
            command.id_quick_answers_hcs = id_quick_answers_hcs;
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id_quick_answers_hcs}")]
        public async Task<IActionResult> DeleteQuick_Answers_hcs(int id_quick_answers_hcs)
        {
            var command = new DeleteQuick_Answers_hcsCommand
            {
                id_quick_answers_hcs = id_quick_answers_hcs
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
