using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Education.Commands.UpdateEducation
{
    public class UpdateEducationCommandValidator : AbstractValidator<UpdateEducationCommand>
    {
        public UpdateEducationCommandValidator()
        {
            RuleFor(updateEntityCommand =>
            updateEntityCommand.text_of_request).MaximumLength(250);
        }
    }
}
