using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Quick_Answers_Healthcare.Queries.GetQuick_Answers_HealthcareDetails
{
    public class GetQuick_Answers_HealthcareDetailsQueryValidator : AbstractValidator<GetQuick_Answers_HealthcareDetailsQuery>
    {
        public GetQuick_Answers_HealthcareDetailsQueryValidator()
        {
            RuleFor(entity => entity.id_quick_answer_healthcare).NotEmpty();
        }
    }
}
