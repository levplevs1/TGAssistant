using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Payments.Commands.CreatePayments
{
    public class CreatePaymentsCommandValidator : AbstractValidator<CreatePaymentsCommand>
    {
        public CreatePaymentsCommandValidator()
        {
            RuleFor(createEntityCommand =>
            createEntityCommand.payments_date);
            RuleFor(createEntityCommand =>
            createEntityCommand.amount);
            RuleFor(createEntityCommand =>
            createEntityCommand.id_users);
            RuleFor(createEntityCommand =>
            createEntityCommand.id_payments_method);
            RuleFor(createEntityCommand =>
            createEntityCommand.id_service_type);
        }
    }
}
