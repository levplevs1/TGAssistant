using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TelegramBot.Application.src.Entities.Reading_History.Commands.CreateReading_History;
using TelegramBot.Application.src.Entities.Reading_History.Commands.DeleteReading_History;
using TelegramBot.Application.src.Entities.Reading_History.Commands.UpdateReading_History;
using TelegramBot.Application.src.Entities.Reading_History.Queries.GetReading_HistoryDetails;
using TelegramBot.Application.src.Entities.Reading_History.Queries.GetReading_HistoryList;
using TelegramBot.Application.src.Entities.Users.Commands.CreateUsers;
using TelegramBot.Application.src.Entities.Users.Commands.DeleteUsers;
using TelegramBot.Application.src.Entities.Users.Commands.UpdateUsers;
using TelegramBot.Application.src.Entities.Users.Queries.GetUsersDetails;
using TelegramBot.Application.src.Entities.Users.Queries.GetUsersList;
using TelegramBot.WebApi.src.EntitiesDto.Reading_History;
using TelegramBot.WebApi.src.EntitiesDto.UsersDto;

namespace TelegramBot.WebApi.src.Controllers
{
    [Route("api/[controller]")]
    public class Reading_HistoryController : BaseController
    {
        private readonly IMapper _mapper;

        public Reading_HistoryController(IMapper mapper) => _mapper = mapper;

        [HttpGet]
        public async Task<ActionResult<Reading_HistoryListVm>> GetAllReading_History()
        {
            var query = new GetReading_HistoryListQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{id_reading_history}")]
        public async Task<ActionResult<Reading_HistoryDetailsVm>> GetReading_HistoryDetails(int id_reading_history)
        {
            var query = new GetReading_HistoryDetailsQuery
            {
                id_reading_history = id_reading_history
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateReading_History([FromBody] CreateReading_HistoryDto createReading_HistoryDto)
        {
            var command = _mapper.Map<CreateReading_HistoryCommand>(createReading_HistoryDto);
            var id_reading_history = await Mediator.Send(command);
            return Ok(id_reading_history);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateReading_History([FromBody] UpdateReading_HistoryDto updateReading_HistoryDto)
        {
            var command = _mapper.Map<UpdateReading_HistoryCommand>(updateReading_HistoryDto);
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id_reading_history}")]
        public async Task<IActionResult> DeleteReading_History(int id_reading_history)
        {
            var command = new DeleteReading_HistoryCommand
            {
                id_reading_history = id_reading_history
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
