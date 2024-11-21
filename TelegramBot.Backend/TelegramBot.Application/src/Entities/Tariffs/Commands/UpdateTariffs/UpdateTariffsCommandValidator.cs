using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Tariffs.Commands.UpdateTariffs
{
    public class UpdateTariffsCommandValidator : AbstractValidator<UpdateTariffsCommand>
    {
        public UpdateTariffsCommandValidator()
        {
            RuleFor(updateEntityCommand =>
            updateEntityCommand.tariff_value);
        }
    }
}
