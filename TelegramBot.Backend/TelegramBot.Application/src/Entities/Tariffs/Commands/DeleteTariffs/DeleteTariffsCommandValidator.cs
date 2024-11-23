using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Tariffs.Commands.DeleteTariffs
{
    public class DeleteTariffsCommandValidator : AbstractValidator<DeleteTariffsCommand>
    {
        public DeleteTariffsCommandValidator()
        {
            RuleFor(deleteEntityCommand => deleteEntityCommand.id_tariffs).NotEmpty();
        }
    }
}
