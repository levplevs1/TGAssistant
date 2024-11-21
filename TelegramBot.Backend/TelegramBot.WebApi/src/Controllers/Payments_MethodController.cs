using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TelegramBot.Application.src.Entities.Payments_Method.Commands.CreatePayments_Method;
using TelegramBot.Application.src.Entities.Payments_Method.Commands.DeletePayments_Method;
using TelegramBot.Application.src.Entities.Payments_Method.Commands.UpdatePayments_Method;
using TelegramBot.Application.src.Entities.Payments_Method.Queries.GetPayments_MethodDetails;
using TelegramBot.Application.src.Entities.Payments_Method.Queries.GetPayments_MethodList;
using TelegramBot.Application.src.Entities.Users.Commands.CreateUsers;
using TelegramBot.Application.src.Entities.Users.Commands.DeleteUsers;
using TelegramBot.Application.src.Entities.Users.Commands.UpdateUsers;
using TelegramBot.Application.src.Entities.Users.Queries.GetUsersDetails;
using TelegramBot.Application.src.Entities.Users.Queries.GetUsersList;
using TelegramBot.WebApi.src.EntitiesDto.Payments_Method;
using TelegramBot.WebApi.src.EntitiesDto.UsersDto;

namespace TelegramBot.WebApi.src.Controllers
{
    [Route("api/[controller]")]
    public class Payments_MethodController : BaseController
    {
        private readonly IMapper _mapper;

        public Payments_MethodController(IMapper mapper) => _mapper = mapper;

        [HttpGet]
        public async Task<ActionResult<Payments_MethodListVm>> GetAllPayments_Method()
        {
            var query = new GetPayments_MethodListQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{id_payments_method}")]
        public async Task<ActionResult<Payments_MethodDetailsVm>> GetPayments_MethodDetails(int id_payments_method)
        {
            var query = new GetPayments_MethodDetailsQuery
            {
                id_payments_method = id_payments_method
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreatePayments_Method([FromBody] CreatePayments_MethodDto createPayments_MethodDto)
        {
            var command = _mapper.Map<CreatePayments_MethodCommand>(createPayments_MethodDto);
            var id_payments_method = await Mediator.Send(command);
            return Ok(id_payments_method);
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePayments_Method([FromBody] UpdatePayments_MethodDto updatePayments_MethodDto)
        {
            var command = _mapper.Map<UpdatePayments_MethodCommand>(updatePayments_MethodDto);
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id_payments_method}")]
        public async Task<IActionResult> DeletePayments_Method(int id_payments_method)
        {
            var command = new DeletePayments_MethodCommand
            {
                id_payments_method = id_payments_method
            };
            await Mediator.Send(command);
            return NoContent();

        }
    }
}