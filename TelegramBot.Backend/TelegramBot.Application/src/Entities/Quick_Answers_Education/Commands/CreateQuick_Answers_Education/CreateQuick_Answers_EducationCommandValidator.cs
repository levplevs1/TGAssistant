using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Quick_Answers_Education.Commands.CreateQuick_Answers_Education
{
    public class CreateQuick_Answers_EducationCommandValidator : AbstractValidator<CreateQuick_Answers_EducationCommand>
    {
        public CreateQuick_Answers_EducationCommandValidator()
        {
            RuleFor(createEntityCommand =>
            createEntityCommand.id_education);
            RuleFor(createEntityCommand =>
            createEntityCommand.quick_answer_education_name).MaximumLength(250);
        }
    }
}
