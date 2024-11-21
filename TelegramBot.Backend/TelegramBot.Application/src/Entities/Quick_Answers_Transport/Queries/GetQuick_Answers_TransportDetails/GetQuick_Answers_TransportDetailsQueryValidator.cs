using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Quick_Answers_Transport.Queries.GetQuick_Answers_TransportDetails
{
    public class GetQuick_Answers_TransportDetailsQueryValidator : AbstractValidator<GetQuick_Answers_TransportDetailsQuery>
    {
        public GetQuick_Answers_TransportDetailsQueryValidator()
        {
            RuleFor(entity => entity.id_quick_answer_transport).NotEmpty();
        }
    }
}
