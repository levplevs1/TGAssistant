using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Healthcare.Queries.GetHealthcareDetails
{
    public class GetHealthcareDetailsQueryValidator : AbstractValidator<GetHealthcareDetailsQuery>
    {
        public GetHealthcareDetailsQueryValidator()
        {
            RuleFor(entity => entity.id_healthcare).NotEmpty();
        }
    }
}
