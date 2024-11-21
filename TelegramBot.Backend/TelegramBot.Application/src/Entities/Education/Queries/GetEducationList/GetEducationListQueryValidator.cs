using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Education.Queries.GetEducationList
{
    public class GetEducationListQueryValidator : AbstractValidator<GetEducationListQuery>
    {
        public GetEducationListQueryValidator()
        {
            RuleFor(entity => entity.id_education);
        }
    }

}
