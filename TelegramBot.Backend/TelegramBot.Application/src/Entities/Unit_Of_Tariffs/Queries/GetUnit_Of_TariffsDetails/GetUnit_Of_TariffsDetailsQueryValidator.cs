using FluentValidation;
using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Unit_Of_Tariffs.Queries.GetUnit_Of_TariffsDetails
{
    public class GetUnit_Of_TariffsDetailsQueryValidator : AbstractValidator<GetUnit_Of_TariffsDetailsQuery>
    {
        public GetUnit_Of_TariffsDetailsQueryValidator()
        {
            RuleFor(entity => entity.id_unit_of_tariffs).NotEmpty();
        }
    }
}
