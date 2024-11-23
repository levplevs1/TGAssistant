using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Education.Queries.GetEducationDetails
{
    public class GetEducationDetailsQueryValidator : AbstractValidator<GetEducationDetailsQuery>
    {
        public GetEducationDetailsQueryValidator()
        {
            RuleFor(entity => entity.id_education).NotEmpty();
        }
    }
}
