using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Quick_Answers_hcs.Commands.UpdateQuick_Answers_hcs
{
    public class UpdateQuick_Answers_hcsCommandValidator : AbstractValidator<UpdateQuick_Answers_hcsCommand>
    {
        public UpdateQuick_Answers_hcsCommandValidator()
        {
            RuleFor(updateEntityCommand =>
            updateEntityCommand.quick_answers_hcs_name).MaximumLength(250);
            RuleFor(updateEntityCommand =>
            updateEntityCommand.quick_answers_hcs_content).MaximumLength(250);
        }
    }
}
