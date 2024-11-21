using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Meters.Queries.GetMetersList
{
    public class GetMetersListQueryValidator : AbstractValidator<GetMetersListQuery>
    {
        public GetMetersListQueryValidator()
        {
            RuleFor(entity => entity.id_meters);
        }
    }
}
