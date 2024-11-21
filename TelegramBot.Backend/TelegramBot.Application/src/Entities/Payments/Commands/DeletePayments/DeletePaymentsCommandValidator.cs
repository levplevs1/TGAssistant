using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Payments.Commands.DeletePayments
{
    public class DeletePaymentsCommandValidator : AbstractValidator<DeletePaymentsCommand>
    {
        public DeletePaymentsCommandValidator()
        {
            RuleFor(deleteEntityCommand => deleteEntityCommand.id_payments).NotEmpty();
        }
    }
}
