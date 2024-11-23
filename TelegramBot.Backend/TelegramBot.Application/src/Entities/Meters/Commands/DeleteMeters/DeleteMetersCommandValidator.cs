using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Meters.Commands.DeleteMeters
{
    public class DeleteMetersCommandValidator : AbstractValidator<DeleteMetersCommand>
    {
        public DeleteMetersCommandValidator()
        {
            RuleFor(deleteEntityCommand => deleteEntityCommand.id_meters).NotEmpty();
        }
    }
}
