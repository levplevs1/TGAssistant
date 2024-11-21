using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Reading_History.Queries.GetReading_HistoryDetails
{
    public class GetReading_HistoryDetailsQueryValidator : AbstractValidator<GetReading_HistoryDetailsQuery>
    {
        public GetReading_HistoryDetailsQueryValidator()
        {
            RuleFor(entity => entity.id_reading_history).NotEmpty();
        }
    }
}
