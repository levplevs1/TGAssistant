using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Meter_Readings.Commands.DeleteMeter_Readings
{
    public class DeleteMeter_ReadingsCommandValidator : AbstractValidator<DeleteMeter_ReadingsCommand>
    {
        public DeleteMeter_ReadingsCommandValidator()
        {
            RuleFor(deleteEntityCommand => deleteEntityCommand.id_meter_readings).NotEmpty();
        }
    }
}
