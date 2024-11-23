using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Payments_Method.Commands.UpdatePayments_Method
{
    public class UpdatePayments_MethodCommandValidator : AbstractValidator<UpdatePayments_MethodCommand>
    {
        public UpdatePayments_MethodCommandValidator()
        {
            RuleFor(updateEntityCommand =>
            updateEntityCommand.payments_method_name).MaximumLength(250);
        }
    }
}
