using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TelegramBot.Application.src.Entities.Healthcare.Commands.CreateHealthcare;
using TelegramBot.Application.src.Entities.Healthcare.Commands.DeleteHealthcare;
using TelegramBot.Application.src.Entities.Healthcare.Commands.UpdateHealthcare;
using TelegramBot.Application.src.Entities.Healthcare.Queries.GetHealthcareDetails;
using TelegramBot.Application.src.Entities.Healthcare.Queries.GetHealthcareList;
using TelegramBot.Application.src.Entities.Users.Commands.CreateUsers;
using TelegramBot.Application.src.Entities.Users.Commands.DeleteUsers;
using TelegramBot.Application.src.Entities.Users.Commands.UpdateUsers;
using TelegramBot.Application.src.Entities.Users.Queries.GetUsersDetails;
using TelegramBot.Application.src.Entities.Users.Queries.GetUsersList;
using TelegramBot.WebApi.src.EntitiesDto.Healthcare;
using TelegramBot.WebApi.src.EntitiesDto.UsersDto;

namespace TelegramBot.WebApi.src.Controllers
{
    [Route("api/[controller]")]
    public class HealthcareController : BaseController
    {
        private readonly IMapper _mapper;

        public HealthcareController(IMapper mapper) => _mapper = mapper;

        [HttpGet]
        public async Task<ActionResult<HealthcareListVm>> GetAllHealthcare()
        {
            var query = new GetHealthcareListQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{id_healthcare}")]
        public async Task<ActionResult<HealthcareDetailsVm>> GetHealthcareDetails(int id_healthcare)
        {
            var query = new GetHealthcareDetailsQuery
            {
                id_healthcare = id_healthcare
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateHealthcare([FromBody] CreateHealthcareDto createHealthcareDto)
        {
            var command = _mapper.Map<CreateHealthcareCommand>(createHealthcareDto);
            var id_healthcare = await Mediator.Send(command);
            return Ok(id_healthcare);
        }

        [HttpPut("{id_healthcare}")]
        public async Task<IActionResult> UpdateHealthcare(int id_healthcare, [FromBody] UpdateHealthcareDto updateHealthcareDto)
        {
            var command = _mapper.Map<UpdateHealthcareCommand>(updateHealthcareDto);
            command.id_healthcare = id_healthcare;
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id_healthcare}")]
        public async Task<IActionResult> DeleteHealthcare(int id_healthcare)
        {
            var command = new DeleteHealthcareCommand
            {
                id_healthcare = id_healthcare
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
