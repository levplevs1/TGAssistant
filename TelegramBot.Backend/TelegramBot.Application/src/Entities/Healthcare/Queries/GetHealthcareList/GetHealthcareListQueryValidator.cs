using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Healthcare.Queries.GetHealthcareList
{
    public class GetHealthcareListQueryValidator : AbstractValidator<GetHealthcareListQuery>
    {
        public GetHealthcareListQueryValidator()
        {
            RuleFor(entity => entity.id_healthcare);
        }
    }
}
