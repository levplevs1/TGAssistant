using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Tariffs.Queries.GetTariffsList
{
    public class GetTariffsListQueryValidator : AbstractValidator<GetTariffsListQuery>
    {
        public GetTariffsListQueryValidator()
        {
            RuleFor(entity => entity.id_tariffs);
        }
    }
}
