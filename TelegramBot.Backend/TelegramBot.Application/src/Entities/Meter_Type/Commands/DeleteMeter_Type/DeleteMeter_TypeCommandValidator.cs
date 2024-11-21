using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Meter_Type.Commands.DeleteMeter_Type
{
    public class DeleteMeter_TypeCommandValidator : AbstractValidator<DeleteMeter_TypeCommand>
    {
        public DeleteMeter_TypeCommandValidator()
        {
            RuleFor(deleteEntityCommand => deleteEntityCommand.id_meter_type).NotEmpty();
        }
    }
}
