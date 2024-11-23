using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TelegramBot.Application.src.Entities.Housing_And_Communal_Services.Commands.CreateHousing_And_Communal_Services;
using TelegramBot.Application.src.Entities.Housing_And_Communal_Services.Commands.DeleteHousing_And_Communal_Services;
using TelegramBot.Application.src.Entities.Housing_And_Communal_Services.Commands.UpdateHousing_And_Communal_Services;
using TelegramBot.Application.src.Entities.Housing_And_Communal_Services.Queries.GetHousing_And_Communal_ServicesDetails;
using TelegramBot.Application.src.Entities.Housing_And_Communal_Services.Queries.GetHousing_And_Communal_ServicesList;
using TelegramBot.Application.src.Entities.Users.Commands.CreateUsers;
using TelegramBot.Application.src.Entities.Users.Commands.DeleteUsers;
using TelegramBot.Application.src.Entities.Users.Commands.UpdateUsers;
using TelegramBot.Application.src.Entities.Users.Queries.GetUsersDetails;
using TelegramBot.Application.src.Entities.Users.Queries.GetUsersList;
using TelegramBot.WebApi.src.EntitiesDto.Housing_And_Communal_Services;
using TelegramBot.WebApi.src.EntitiesDto.UsersDto;

namespace TelegramBot.WebApi.src.Controllers
{
    [Route("api/[controller]")]
    public class Housing_And_Communal_ServicesController : BaseController
    {
        private readonly IMapper _mapper;

        public Housing_And_Communal_ServicesController(IMapper mapper) => _mapper = mapper;

        [HttpGet]
        public async Task<ActionResult<Housing_And_Communal_ServicesListVm>> GetAllHousing_And_Communal_Services()
        {
            var query = new GetHousing_And_Communal_ServicesListQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{id_housing_and_communal_services}")]
        public async Task<ActionResult<Housing_And_Communal_ServicesDetailsVm>> GetHousing_And_Communal_ServicesDetails(int id_housing_and_communal_services)
        {
            var query = new GetHousing_And_Communal_ServicesDetailsQuery
            {
                id_housing_and_communal_services = id_housing_and_communal_services
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateHousing_And_Communal_Services([FromBody] CreateHousing_And_Communal_ServicesDto createHousing_And_Communal_ServicesDto)
        {
            var command = _mapper.Map<CreateHousing_And_Communal_ServicesCommand>(createHousing_And_Communal_ServicesDto);
            var id_housing_and_communal_services = await Mediator.Send(command);
            return Ok(id_housing_and_communal_services);
        }

        [HttpPut("{id_housing_and_communal_services}")]
        public async Task<IActionResult> UpdateHousing_And_Communal_Services(int id_housing_and_communal_services, [FromBody] UpdateHousing_And_Communal_ServicesDto updateHousing_And_Communal_ServicesDto)
        {
            var command = _mapper.Map<UpdateHousing_And_Communal_ServicesCommand>(updateHousing_And_Communal_ServicesDto);
            command.id_housing_and_communal_services = id_housing_and_communal_services;
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id_housing_and_communal_services}")]
        public async Task<IActionResult> DeleteHousing_And_Communal_Services(int id_housing_and_communal_services)
        {
            var command = new DeleteHousing_And_Communal_ServicesCommand
            {
                id_housing_and_communal_services = id_housing_and_communal_services
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
