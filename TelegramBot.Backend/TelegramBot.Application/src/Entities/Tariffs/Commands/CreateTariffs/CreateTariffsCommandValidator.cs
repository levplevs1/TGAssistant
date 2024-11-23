using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Tariffs.Commands.CreateTariffs
{
    public class CreateTariffsCommandValidator : AbstractValidator<CreateTariffsCommand>
    {
        public CreateTariffsCommandValidator()
        {
            RuleFor(createEntityCommand =>
            createEntityCommand.effective_date);
            RuleFor(createEntityCommand =>
            createEntityCommand.tariff_value);
            RuleFor(createEntityCommand =>
            createEntityCommand.id_housing_and_communal_services);
            RuleFor(createEntityCommand =>
            createEntityCommand.id_service_type);
            RuleFor(createEntityCommand =>
            createEntityCommand.id_unit_of_tariffs);
        }
    }
}
