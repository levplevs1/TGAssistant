using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Unit_Of_Tariffs.Commands.DeleteUnit_Of_Tariffs
{
    public class DeleteUnit_Of_TariffsCommandValidator : AbstractValidator<DeleteUnit_Of_TariffsCommand>
    {
        public DeleteUnit_Of_TariffsCommandValidator()
        {
            RuleFor(deleteEntityCommand => deleteEntityCommand.id_unit_of_tariffs).NotEmpty();
        }
    }
}
