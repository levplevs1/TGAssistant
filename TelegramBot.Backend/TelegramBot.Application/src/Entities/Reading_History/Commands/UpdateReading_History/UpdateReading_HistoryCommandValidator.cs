using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Reading_History.Commands.UpdateReading_History
{
    public class UpdateReading_HistoryCommandValidator : AbstractValidator<UpdateReading_HistoryCommand>
    {
        public UpdateReading_HistoryCommandValidator()
        {
            RuleFor(updateEntityCommand =>
            updateEntityCommand.reading_value).MaximumLength(250);
        }
    }
}
