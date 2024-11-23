using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Meters.Commands.UpdateMeters
{
    public class UpdateMetersCommandValidator : AbstractValidator<UpdateMetersCommand>
    {
        public UpdateMetersCommandValidator()
        {
            RuleFor(updateEntityCommand =>
            updateEntityCommand.last_reading_date);
            RuleFor(updateEntityCommand =>
            updateEntityCommand.id_meter_type);
            RuleFor(updateEntityCommand =>
            updateEntityCommand.id_users);
        }
    }
}
