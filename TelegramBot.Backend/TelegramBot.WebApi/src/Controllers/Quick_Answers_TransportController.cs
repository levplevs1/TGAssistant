using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TelegramBot.Application.src.Entities.Quick_Answers_Transport.Commands.CreateQuick_Answers_Transport;
using TelegramBot.Application.src.Entities.Quick_Answers_Transport.Commands.DeleteQuick_Answers_Transport;
using TelegramBot.Application.src.Entities.Quick_Answers_Transport.Commands.UpdateQuick_Answers_Transport;
using TelegramBot.Application.src.Entities.Quick_Answers_Transport.Queries.GetQuick_Answers_TransportDetails;
using TelegramBot.Application.src.Entities.Quick_Answers_Transport.Queries.GetQuick_Answers_TransportList;
using TelegramBot.Application.src.Entities.Users.Commands.CreateUsers;
using TelegramBot.Application.src.Entities.Users.Commands.DeleteUsers;
using TelegramBot.Application.src.Entities.Users.Commands.UpdateUsers;
using TelegramBot.Application.src.Entities.Users.Queries.GetUsersDetails;
using TelegramBot.Application.src.Entities.Users.Queries.GetUsersList;
using TelegramBot.WebApi.src.EntitiesDto.Quick_Answers_Transport;
using TelegramBot.WebApi.src.EntitiesDto.UsersDto;

namespace TelegramBot.WebApi.src.Controllers
{
    [Route("api/[controller]")]
    public class Quick_Answers_TransportController : BaseController
    {
        private readonly IMapper _mapper;

        public Quick_Answers_TransportController(IMapper mapper) => _mapper = mapper;

        [HttpGet]
        public async Task<ActionResult<Quick_Answers_TransportListVm>> GetAllQuick_Answers_Transport()
        {
            var query = new GetQuick_Answers_TransportListQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{id_quick_answer_transport}")]
        public async Task<ActionResult<Quick_Answers_TransportDetailsVm>> GetQuick_Answers_TransportDetails(int id_quick_answer_transport)
        {
            var query = new GetQuick_Answers_TransportDetailsQuery
            {
                id_quick_answer_transport = id_quick_answer_transport
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateQuick_Answers_Transport([FromBody] CreateQuick_Answers_TransportDto createQuick_Answers_TransportDto)
        {
            var command = _mapper.Map<CreateQuick_Answers_TransportCommand>(createQuick_Answers_TransportDto);
            var id_quick_answer_transport = await Mediator.Send(command);
            return Ok(id_quick_answer_transport);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateQuick_Answers_Transport([FromBody] UpdateQuick_Answers_TransportDto updateQuick_Answers_TransportDto)
        {
            var command = _mapper.Map<UpdateQuick_Answers_TransportCommand>(updateQuick_Answers_TransportDto);
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id_quick_answer_transport}")]
        public async Task<IActionResult> DeleteQuick_Answers_Transport(int id_quick_answer_transport)
        {
            var command = new DeleteQuick_Answers_TransportCommand
            {
                id_quick_answer_transport = id_quick_answer_transport
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
