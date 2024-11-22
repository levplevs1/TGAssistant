using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Payments_Method.Commands.DeletePayments_Method
{
    public class DeletePayments_MethodCommandValidator : AbstractValidator<DeletePayments_MethodCommand>
    {
        public DeletePayments_MethodCommandValidator()
        {
            RuleFor(deleteEntityCommand => deleteEntityCommand.id_payments_method).NotEmpty();
        }
    }
}
