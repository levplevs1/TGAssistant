using FluentValidation;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Meter_Type.Queries.GetMeter_TypeDetails
{
    public class GetMeter_TypeDetailsQueryValidator : AbstractValidator<GetMeter_TypeDetailsQuery>
    {
        public GetMeter_TypeDetailsQueryValidator()
        {
            RuleFor(entity => entity.id_meter_type).NotEmpty();
        }
    }
}
