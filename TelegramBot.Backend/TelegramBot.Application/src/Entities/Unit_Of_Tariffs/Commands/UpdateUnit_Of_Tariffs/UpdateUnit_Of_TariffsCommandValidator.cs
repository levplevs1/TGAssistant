using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Entities.Unit_Of_Tariffs.Commands.DeleteUnit_Of_Tariffs;

namespace TelegramBot.Application.src.Entities.Unit_Of_Tariffs.Commands.UpdateUnit_Of_Tariffs
{
    public class UpdateUnit_Of_TariffsCommandValidator : AbstractValidator<UpdateUnit_Of_TariffsCommand>
    {
        public UpdateUnit_Of_TariffsCommandValidator()
        {
            RuleFor(updateEntityCommand =>
            updateEntityCommand.unit_of_tariffs_name).MaximumLength(250);
        }
    }
}
