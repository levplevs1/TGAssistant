using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Quick_Answers_Healthcare.Queries.GetQuick_Answers_HealthcareList
{
    public class GetQuick_Answers_HealthcareListQueryValidator : AbstractValidator<GetQuick_Answers_HealthcareListQuery>
    {
        public GetQuick_Answers_HealthcareListQueryValidator()
        {
            RuleFor(entity => entity.id_quick_answer_healthcare);
        }
    }
}
