using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Quick_Answers_Healthcare.Commands.DeleteQuick_Answers_Healthcare
{
    public class DeleteQuick_Answers_HealthcareCommandValidator : AbstractValidator<DeleteQuick_Answers_HealthcareCommand>
    {
        public DeleteQuick_Answers_HealthcareCommandValidator()
        {
            RuleFor(deleteEntityCommand => deleteEntityCommand.id_quick_answer_healthcare).NotEmpty();
        }
    }
}
