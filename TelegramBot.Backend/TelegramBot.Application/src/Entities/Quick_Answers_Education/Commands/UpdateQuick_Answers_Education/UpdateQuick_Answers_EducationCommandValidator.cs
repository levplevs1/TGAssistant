using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Quick_Answers_Education.Commands.UpdateQuick_Answers_Education
{
    public class UpdateQuick_Answers_EducationCommandValidator : AbstractValidator<UpdateQuick_Answers_EducationCommand>
    {
        public UpdateQuick_Answers_EducationCommandValidator()
        {
            RuleFor(updateEntityCommand =>
            updateEntityCommand.quick_answer_education_name).MaximumLength(250);
        }
    }
}
