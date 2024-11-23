using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Payments_Method.Commands.CreatePayments_Method
{
    public class CreatePayments_MethodCommandValidator : AbstractValidator<CreatePayments_MethodCommand>
    {
        public CreatePayments_MethodCommandValidator()
        {
            RuleFor(createEntityCommand =>
            createEntityCommand.payments_method_name).MaximumLength(250);
        }
    }
}
