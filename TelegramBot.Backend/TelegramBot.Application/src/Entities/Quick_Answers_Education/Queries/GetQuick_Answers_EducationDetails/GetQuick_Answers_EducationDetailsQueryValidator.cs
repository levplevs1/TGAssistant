using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Quick_Answers_Education.Queries.GetQuick_Answers_EducationDetails
{
    public class GetQuick_Answers_EducationDetailsQueryValidator : AbstractValidator<GetQuick_Answers_EducationDetailsQuery>
    {
        public GetQuick_Answers_EducationDetailsQueryValidator()
        {
            RuleFor(entity => entity.id_quick_answer_education).NotEmpty();
        }
    }
}
