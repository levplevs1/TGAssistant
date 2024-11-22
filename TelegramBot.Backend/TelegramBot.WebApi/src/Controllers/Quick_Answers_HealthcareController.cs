using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TelegramBot.Application.src.Common.Mapping;
using TelegramBot.Application.src.Entities.Quick_Answers_Healthcare.Commands.CreateQuick_Answers_Healthcare;
using TelegramBot.Application.src.Entities.Quick_Answers_Healthcare.Commands.DeleteQuick_Answers_Healthcare;
using TelegramBot.Application.src.Entities.Quick_Answers_Healthcare.Commands.UpdateQuick_Answers_Healthcare;
using TelegramBot.Application.src.Entities.Quick_Answers_Healthcare.Queries.GetQuick_Answers_HealthcareDetails;
using TelegramBot.Application.src.Entities.Quick_Answers_Healthcare.Queries.GetQuick_Answers_HealthcareList;
using TelegramBot.Application.src.Entities.Users.Commands.CreateUsers;
using TelegramBot.Application.src.Entities.Users.Commands.DeleteUsers;
using TelegramBot.Application.src.Entities.Users.Commands.UpdateUsers;
using TelegramBot.Application.src.Entities.Users.Queries.GetUsersDetails;
using TelegramBot.Application.src.Entities.Users.Queries.GetUsersList;
using TelegramBot.WebApi.src.EntitiesDto.Quick_Answers_Healthcare;
using TelegramBot.WebApi.src.EntitiesDto.UsersDto;

namespace TelegramBot.WebApi.src.Controllers
{
    [Route("api/[controller]")]
    public class Quick_Answers_HealthcareController : BaseController
    {
        private readonly IMapper _mapper;

        public Quick_Answers_HealthcareController(IMapper mapper) => _mapper = mapper;

        [HttpGet]
        public async Task<ActionResult<Quick_Answers_HealthcareListVm>> GetAllQuick_Answers_Healthcare()
        {
            var query = new GetQuick_Answers_HealthcareListQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{id_quick_answer_healthcare}")]
        public async Task<ActionResult<Quick_Answers_HealthcareDetailsVm>> GetQuick_Answers_HealthcareDetails(int id_quick_answer_healthcare)
        {
            var query = new GetQuick_Answers_HealthcareDetailsQuery
            {
                id_quick_answer_healthcare = id_quick_answer_healthcare
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateQuick_Answers_Healthcare([FromBody] CreateQuick_Answers_HealthcareDto createQuick_Answers_HealthcareDto)
        {
            var command = _mapper.Map<CreateQuick_Answers_HealthcareCommand>(createQuick_Answers_HealthcareDto);
            var id_quick_answer_healthcare = await Mediator.Send(command);
            return Ok(id_quick_answer_healthcare);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateQuick_Answers_Healthcare([FromBody] UpdateQuick_Answers_HealthcareDto updateQuick_Answers_HealthcareDto)
        {
            var command = _mapper.Map<UpdateQuick_Answers_HealthcareCommand>(updateQuick_Answers_HealthcareDto);
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id_quick_answer_healthcare}")]
        public async Task<IActionResult> DeleteQuick_Answers_Healthcare(int id_quick_answer_healthcare)
        {
            var command = new DeleteQuick_Answers_HealthcareCommand
            {
                id_quick_answer_healthcare = id_quick_answer_healthcare
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
