using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Reading_History.Queries.GetReading_HistoryList
{
    public class GetReading_HistoryListQueryValidator : AbstractValidator<GetReading_HistoryListQuery>
    {
        public GetReading_HistoryListQueryValidator()
        {
            RuleFor(entity => entity.id_reading_history);
        }
    }
}
