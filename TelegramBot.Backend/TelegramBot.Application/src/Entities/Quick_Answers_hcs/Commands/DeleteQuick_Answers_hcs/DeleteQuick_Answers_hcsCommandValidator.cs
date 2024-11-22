using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Quick_Answers_hcs.Commands.DeleteQuick_Answers_hcs
{
    public class DeleteQuick_Answers_hcsCommandValidator : AbstractValidator<DeleteQuick_Answers_hcsCommand>
    {
        public DeleteQuick_Answers_hcsCommandValidator()
        {
            RuleFor(deleteEntityCommand => deleteEntityCommand.id_quick_answers_hcs).NotEmpty();
        }
    }
}
