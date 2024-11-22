using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Quick_Answers_Healthcare.Commands.UpdateQuick_Answers_Healthcare
{
    public class UpdateQuick_Answers_HealthcareCommandValidator : AbstractValidator<UpdateQuick_Answers_HealthcareCommand>
    {
        public UpdateQuick_Answers_HealthcareCommandValidator()
        {
            RuleFor(updateEntityCommand =>
            updateEntityCommand.quick_answer_healthcare_name).MaximumLength(250);
        }
    }
}
