using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Meters.Queries.GetMetersDetails
{
    public class GetMetersDetailsQueryValidator : AbstractValidator<GetMetersDetailsQuery>
    {
        public GetMetersDetailsQueryValidator()
        {
            RuleFor(entity => entity.id_meters).NotEmpty();
        }
    }
}
