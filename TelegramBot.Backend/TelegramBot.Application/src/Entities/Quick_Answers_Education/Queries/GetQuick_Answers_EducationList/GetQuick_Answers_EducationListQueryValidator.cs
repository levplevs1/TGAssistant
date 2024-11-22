using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Quick_Answers_Education.Queries.GetQuick_Answers_EducationList
{
    public class GetQuick_Answers_EducationListQueryValidator : AbstractValidator<GetQuick_Answers_EducationListQuery>
    {
        public GetQuick_Answers_EducationListQueryValidator()
        {
            RuleFor(entity => entity.id_quick_answer_education);
        }
    }
}
