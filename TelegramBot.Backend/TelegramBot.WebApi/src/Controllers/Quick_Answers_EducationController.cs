using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TelegramBot.Application.src.Entities.Quick_Answers_Education.Commands.CreateQuick_Answers_Education;
using TelegramBot.Application.src.Entities.Quick_Answers_Education.Commands.DeleteQuick_Answers_Education;
using TelegramBot.Application.src.Entities.Quick_Answers_Education.Commands.UpdateQuick_Answers_Education;
using TelegramBot.Application.src.Entities.Quick_Answers_Education.Queries.GetQuick_Answers_EducationDetails;
using TelegramBot.Application.src.Entities.Quick_Answers_Education.Queries.GetQuick_Answers_EducationList;
using TelegramBot.Application.src.Entities.Users.Commands.CreateUsers;
using TelegramBot.Application.src.Entities.Users.Commands.DeleteUsers;
using TelegramBot.Application.src.Entities.Users.Commands.UpdateUsers;
using TelegramBot.Application.src.Entities.Users.Queries.GetUsersDetails;
using TelegramBot.Application.src.Entities.Users.Queries.GetUsersList;
using TelegramBot.WebApi.src.EntitiesDto.Quick_Answers_Education;
using TelegramBot.WebApi.src.EntitiesDto.UsersDto;

namespace TelegramBot.WebApi.src.Controllers
{
    [Route("api/[controller]")]
    public class Quick_Answers_EducationController : BaseController
    {
        private readonly IMapper _mapper;

        public Quick_Answers_EducationController(IMapper mapper) => _mapper = mapper;

        [HttpGet]
        public async Task<ActionResult<Quick_Answers_EducationListVm>> GetAllQuick_Answers_Education()
        {
            var query = new GetQuick_Answers_EducationListQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{id_quick_answer_education}")]
        public async Task<ActionResult<Quick_Answers_EducationDetailsVm>> GetQuick_Answers_EducationDetails(int id_quick_answer_education)
        {
            var query = new GetQuick_Answers_EducationDetailsQuery
            {
                id_quick_answer_education = id_quick_answer_education
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateQuick_Answers_Education([FromBody] CreateQuick_Answers_EducationDto createQuick_Answers_EducationDto)
        {
            var command = _mapper.Map<CreateQuick_Answers_EducationCommand>(createQuick_Answers_EducationDto);
            var id_quick_answer_education = await Mediator.Send(command);
            return Ok(id_quick_answer_education);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateQuick_Answers_Education([FromBody] UpdateQuick_Answers_EducationDto updateQuick_Answers_EducationDto)
        {
            var command = _mapper.Map<UpdateQuick_Answers_EducationCommand>(updateQuick_Answers_EducationDto);
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id_quick_answer_education}")]
        public async Task<IActionResult> DeleteQuick_Answers_Education(int id_quick_answer_education)
        {
            var command = new DeleteQuick_Answers_EducationCommand
            {
                id_quick_answer_education = id_quick_answer_education
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
