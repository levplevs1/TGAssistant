using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Quick_Answers_Healthcare.Commands.CreateQuick_Answers_Healthcare
{
    public class CreateQuick_Answers_HealthcareCommandValidator : AbstractValidator<CreateQuick_Answers_HealthcareCommand>
    {
        public CreateQuick_Answers_HealthcareCommandValidator()
        {
            RuleFor(createEntityCommand =>
            createEntityCommand.id_healthcare);
            RuleFor(createEntityCommand =>
            createEntityCommand.quick_answer_healthcare_name).MaximumLength(250);
        }
    }
}
