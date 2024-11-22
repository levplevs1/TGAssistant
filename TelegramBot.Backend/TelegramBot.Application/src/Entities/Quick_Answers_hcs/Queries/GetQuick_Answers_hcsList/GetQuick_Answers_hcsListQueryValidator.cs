using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Quick_Answers_hcs.Queries.GetQuick_Answers_hcsList
{
    public class GetQuick_Answers_hcsListQueryValidator : AbstractValidator<GetQuick_Answers_hcsListQuery>
    {
        public GetQuick_Answers_hcsListQueryValidator()
        {
            RuleFor(entity => entity.id_quick_answers_hcs);
        }
    }
}
