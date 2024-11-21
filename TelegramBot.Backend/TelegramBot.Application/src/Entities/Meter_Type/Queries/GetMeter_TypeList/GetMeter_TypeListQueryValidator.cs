using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Meter_Type.Queries.GetMeter_TypeList
{
    public class GetMeter_TypeListQueryValidator : AbstractValidator<GetMeter_TypeListQuery>
    {
        public GetMeter_TypeListQueryValidator()
        {
            RuleFor(entity => entity.id_meter_type);
        }
    }
}
