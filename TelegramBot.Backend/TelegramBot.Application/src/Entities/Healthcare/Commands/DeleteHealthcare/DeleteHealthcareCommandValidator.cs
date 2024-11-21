using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Healthcare.Commands.DeleteHealthcare
{
    public class DeleteHealthcareCommandValidator : AbstractValidator<DeleteHealthcareCommand>
    {
        public DeleteHealthcareCommandValidator()
        {
            RuleFor(deleteEntityCommand => deleteEntityCommand.id_healthcare).NotEmpty();
        }
    }
}
