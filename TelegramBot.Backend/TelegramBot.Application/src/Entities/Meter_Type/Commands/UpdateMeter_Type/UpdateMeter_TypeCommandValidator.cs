using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Meter_Type.Commands.UpdateMeter_Type
{
    public class UpdateMeter_TypeCommandValidator : AbstractValidator<UpdateMeter_TypeCommand>
    {
        public UpdateMeter_TypeCommandValidator()
        {
            RuleFor(updateEntityCommand =>
            updateEntityCommand.meter_type_name).MaximumLength(250);
        }
    }
}
