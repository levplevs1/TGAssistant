using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Healthcare.Commands.CreateHealthcare
{
    public class CreateHealthcareCommandValidator : AbstractValidator<CreateHealthcareCommand>
    {
        public CreateHealthcareCommandValidator()
        {
            RuleFor(createEntityCommand =>
            createEntityCommand.text_of_request).MaximumLength(250);
            RuleFor(createEntityCommand =>
            createEntityCommand.created_at);
        }
    }
}
