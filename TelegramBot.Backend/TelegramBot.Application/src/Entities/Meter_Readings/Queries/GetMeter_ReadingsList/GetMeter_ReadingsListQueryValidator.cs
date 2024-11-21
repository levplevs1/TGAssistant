using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Meter_Readings.Queries.GetMeter_ReadingsList
{
    public class GetMeter_ReadingsListQueryValidator : AbstractValidator<GetMeter_ReadingsListQuery>
    {
        public GetMeter_ReadingsListQueryValidator()
        {
            RuleFor(entity => entity.id_meter_readings);
        }
    }
}
