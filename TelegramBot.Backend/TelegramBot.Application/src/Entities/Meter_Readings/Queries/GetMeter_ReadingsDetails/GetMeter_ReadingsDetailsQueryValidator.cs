using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Meter_Readings.Queries.GetMeter_ReadingsDetails
{
    public class GetMeter_ReadingsDetailsQueryValidator : AbstractValidator<GetMeter_ReadingsDetailsQuery>
    {
        public GetMeter_ReadingsDetailsQueryValidator()
        {
            RuleFor(entity => entity.id_meter_readings).NotEmpty();
        }
    }
}
