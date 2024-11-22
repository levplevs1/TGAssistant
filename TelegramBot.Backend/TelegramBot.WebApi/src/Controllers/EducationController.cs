using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TelegramBot.Application.src.Entities.Education.Commands.CreateEducation;
using TelegramBot.Application.src.Entities.Education.Commands.DeleteEducation;
using TelegramBot.Application.src.Entities.Education.Commands.UpdateEducation;
using TelegramBot.Application.src.Entities.Education.Queries.GetEducationDetails;
using TelegramBot.Application.src.Entities.Education.Queries.GetEducationList;
using TelegramBot.Application.src.Entities.Users.Commands.CreateUsers;
using TelegramBot.Application.src.Entities.Users.Commands.DeleteUsers;
using TelegramBot.Application.src.Entities.Users.Commands.UpdateUsers;
using TelegramBot.Application.src.Entities.Users.Queries.GetUsersDetails;
using TelegramBot.Application.src.Entities.Users.Queries.GetUsersList;
using TelegramBot.WebApi.src.EntitiesDto.Education;
using TelegramBot.WebApi.src.EntitiesDto.UsersDto;

namespace TelegramBot.WebApi.src.Controllers
{
    [Route("api/[controller]")]
    public class EducationController : BaseController
    {
        private readonly IMapper _mapper;

        public EducationController(IMapper mapper) => _mapper = mapper;

        [HttpGet]
        public async Task<ActionResult<EducationListVm>> GetAllEducation()
        {
            var query = new GetEducationListQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{id_education}")]
        public async Task<ActionResult<EducationDetailsVm>> GetEducationDetails(int id_education)
        {
            var query = new GetEducationDetailsQuery
            {
                id_education = id_education
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateEducation([FromBody] CreateEducationDto createEducationDto)
        {
            var command = _mapper.Map<CreateEducationCommand>(createEducationDto);
            var id_education = await Mediator.Send(command);
            return Ok(id_education);
        }

        [HttpPut("{id_education}")]
        public async Task<IActionResult> UpdateEducation(int id_education, [FromBody] UpdateEducationDto updateEducationDto)
        {
            var command = _mapper.Map<UpdateEducationCommand>(updateEducationDto);
            command.id_education = id_education;
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id_education}")]
        public async Task<IActionResult> DeleteEducation(int id_education)
        {
            var command = new DeleteEducationCommand
            {
                id_education = id_education
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
