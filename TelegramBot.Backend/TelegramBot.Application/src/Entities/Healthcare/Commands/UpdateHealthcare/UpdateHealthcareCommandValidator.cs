using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Healthcare.Commands.UpdateHealthcare
{
    public class UpdateHealthcareCommandValidator : AbstractValidator<UpdateHealthcareCommand>
    {
        public UpdateHealthcareCommandValidator()
        {
            RuleFor(updateEntityCommand =>
            updateEntityCommand.text_of_request).MaximumLength(250);
        }
    }
}
