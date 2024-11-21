using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Meter_Readings.Commands.CreateMeter_Readings
{
    public class CreateMeter_ReadingsCommandValidator : AbstractValidator<CreateMeter_ReadingsCommand>
    {
        public CreateMeter_ReadingsCommandValidator()
        {
            RuleFor(createEntityCommand =>
            createEntityCommand.readings_value).MaximumLength(250);
            RuleFor(createEntityCommand =>
            createEntityCommand.previos_readings_value).MaximumLength(250);
            RuleFor(createEntityCommand =>
            createEntityCommand.readings_date);
            RuleFor(createEntityCommand =>
            createEntityCommand.id_meters);
            RuleFor(createEntityCommand =>
            createEntityCommand.id_housing_and_communal_services);
        }
    }
}
