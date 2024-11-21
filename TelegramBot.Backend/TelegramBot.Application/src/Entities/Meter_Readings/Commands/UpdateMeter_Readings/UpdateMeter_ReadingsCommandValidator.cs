using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Meter_Readings.Commands.UpdateMeter_Readings
{
    public class UpdateMeter_ReadingsCommandValidator : AbstractValidator<UpdateMeter_ReadingsCommand>
    {
        public UpdateMeter_ReadingsCommandValidator()
        {
            RuleFor(updateEntityCommand =>
            updateEntityCommand.readings_value).MaximumLength(250);
            RuleFor(updateEntityCommand =>
            updateEntityCommand.previos_readings_value).MaximumLength(250);
        }
    }
}
