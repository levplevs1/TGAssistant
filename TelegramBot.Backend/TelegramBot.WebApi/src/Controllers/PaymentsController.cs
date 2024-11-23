using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TelegramBot.Application.src.Entities.Payments.Commands.CreatePayments;
using TelegramBot.Application.src.Entities.Payments.Commands.DeletePayments;
using TelegramBot.Application.src.Entities.Payments.Commands.UpdatePayments;
using TelegramBot.Application.src.Entities.Payments.Queries.GetPaymentsDetails;
using TelegramBot.Application.src.Entities.Payments.Queries.GetPaymentsList;
using TelegramBot.Application.src.Entities.Users.Commands.CreateUsers;
using TelegramBot.Application.src.Entities.Users.Commands.DeleteUsers;
using TelegramBot.Application.src.Entities.Users.Commands.UpdateUsers;
using TelegramBot.Application.src.Entities.Users.Queries.GetUsersDetails;
using TelegramBot.Application.src.Entities.Users.Queries.GetUsersList;
using TelegramBot.WebApi.src.EntitiesDto.Payments;
using TelegramBot.WebApi.src.EntitiesDto.UsersDto;

namespace TelegramBot.WebApi.src.Controllers
{
    [Route("api/[controller]")]
    public class PaymentsController : BaseController
    {
        private readonly IMapper _mapper;

        public PaymentsController(IMapper mapper) => _mapper = mapper;

        [HttpGet]
        public async Task<ActionResult<PaymentsListVm>> GetAllPayments()
        {
            var query = new GetPaymentsListQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{id_payments}")]
        public async Task<ActionResult<PaymentsDetailsVm>> GetPaymentsDetails(int id_payments)
        {
            var query = new GetPaymentsDetailsQuery
            {
                id_payments = id_payments
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreatePayments([FromBody] CreatePaymentsDto createPaymentsDto)
        {
            var command = _mapper.Map<CreatePaymentsCommand>(createPaymentsDto);
            var id_payments = await Mediator.Send(command);
            return Ok(id_payments);
        }

        [HttpPut("{id_payments}")]
        public async Task<IActionResult> UpdatePayments(int id_payments, [FromBody] UpdatePaymentsDto updatePaymentsDto)
        {
            var command = _mapper.Map<UpdatePaymentsCommand>(updatePaymentsDto);
            command.id_payments = id_payments;
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id_payments}")]
        public async Task<IActionResult> DeletePayments(int id_payments)
        {
            var command = new DeletePaymentsCommand
            {
                id_payments = id_payments
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
