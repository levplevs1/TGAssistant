using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Quick_Answers_Transport.Queries.GetQuick_Answers_TransportList
{
    public class GetQuick_Answers_TransportListQueryValidator : AbstractValidator<GetQuick_Answers_TransportListQuery>
    {
        public GetQuick_Answers_TransportListQueryValidator()
        {
            RuleFor(entity => entity.id_quick_answer_transport);
        }
    }
}
