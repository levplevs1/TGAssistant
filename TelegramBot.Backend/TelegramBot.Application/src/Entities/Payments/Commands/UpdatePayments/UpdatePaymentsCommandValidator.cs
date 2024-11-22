using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Payments.Commands.UpdatePayments
{
    public class UpdatePaymentsCommandValidator : AbstractValidator<UpdatePaymentsCommand>
    {
        public UpdatePaymentsCommandValidator()
        {
            RuleFor(updateEntityCommand =>
            updateEntityCommand.amount);
        }
    }
}
