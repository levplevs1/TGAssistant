using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Tariffs.Queries.GetTariffsDetails
{
    public class GetTariffsDetailsQueryValidator : AbstractValidator<GetTariffsDetailsQuery>
    {
        public GetTariffsDetailsQueryValidator()
        {
            RuleFor(entity => entity.id_tariffs).NotEmpty();
        }
    }
}
