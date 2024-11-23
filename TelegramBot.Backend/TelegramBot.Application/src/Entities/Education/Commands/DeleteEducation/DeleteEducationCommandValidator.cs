using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Education.Commands.DeleteEducation
{
    public class DeleteEducationCommandValidator : AbstractValidator<DeleteEducationCommand>
    {
        public DeleteEducationCommandValidator()
        {
            RuleFor(deleteEntityCommand => deleteEntityCommand.id_education).NotEmpty();
        }
    }
}
