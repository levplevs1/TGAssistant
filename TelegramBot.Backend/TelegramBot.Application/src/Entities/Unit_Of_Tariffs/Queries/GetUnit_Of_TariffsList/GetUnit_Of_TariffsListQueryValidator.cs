using FluentValidation;
using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Unit_Of_Tariffs.Queries.GetUnit_Of_TariffsList
{
    public class GetUnit_Of_TariffsListQueryValidator : AbstractValidator<GetUnit_Of_TariffsListQuery>
    {
        public GetUnit_Of_TariffsListQueryValidator()
        {
            RuleFor(entity => entity.id_unit_of_tariffs);
        }
    }
}
