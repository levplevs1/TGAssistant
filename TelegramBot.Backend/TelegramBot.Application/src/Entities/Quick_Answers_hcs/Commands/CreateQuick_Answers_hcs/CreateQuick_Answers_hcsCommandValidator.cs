using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Quick_Answers_hcs.Commands.CreateQuick_Answers_hcs
{
    public class CreateQuick_Answers_hcsCommandValidator : AbstractValidator<CreateQuick_Answers_hcsCommand>
    {
        public CreateQuick_Answers_hcsCommandValidator()
        {
            RuleFor(createEntityCommand =>
            createEntityCommand.quick_answers_hcs_name).MaximumLength(250);
            RuleFor(createEntityCommand =>
            createEntityCommand.quick_answers_hcs_content).MaximumLength(250);
            RuleFor(createEntityCommand =>
            createEntityCommand.id_housing_and_communal_services);
        }
    }
}
