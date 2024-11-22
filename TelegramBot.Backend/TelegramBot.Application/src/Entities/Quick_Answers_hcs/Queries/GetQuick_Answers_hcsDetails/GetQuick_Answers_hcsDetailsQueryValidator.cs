using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Quick_Answers_hcs.Queries.GetQuick_Answers_hcsDetails
{
    public class GetQuick_Answers_hcsDetailsQueryValidator : AbstractValidator<GetQuick_Answers_hcsDetailsQuery>
    {
        public GetQuick_Answers_hcsDetailsQueryValidator()
        {
            RuleFor(entity => entity.id_quick_answers_hcs).NotEmpty();
        }
    }
}
