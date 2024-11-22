using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Meters.Commands.CreateMeters
{
    public class CreateMetersCommandValidator : AbstractValidator<CreateMetersCommand>
    {
        public CreateMetersCommandValidator()
        {
            RuleFor(createEntityCommand =>
            createEntityCommand.instalition_date);
            RuleFor(createEntityCommand =>
            createEntityCommand.last_reading_date);
            RuleFor(createEntityCommand =>
            createEntityCommand.id_meter_type);
            RuleFor(createEntityCommand =>
            createEntityCommand.id_users);
        }
    }
}
