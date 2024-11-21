using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Meter_Type.Commands.CreateMeter_Type
{
    public class CreateMeter_TypeCommandValidator : AbstractValidator<CreateMeter_TypeCommand>
    {
        public CreateMeter_TypeCommandValidator()
        {
            RuleFor(createEntityCommand =>
            createEntityCommand.meter_type_name).MaximumLength(250);
        }
    }
}
