using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Reading_History.Commands.CreateReading_History
{
    public class CreateReading_HistoryCommandValidator : AbstractValidator<CreateReading_HistoryCommand>
    {
        public CreateReading_HistoryCommandValidator()
        {
            RuleFor(createEntityCommand =>
            createEntityCommand.reading_date);
            RuleFor(createEntityCommand =>
            createEntityCommand.reading_value).MaximumLength(250);
            RuleFor(createEntityCommand =>
            createEntityCommand.id_meters);
            RuleFor(createEntityCommand =>
            createEntityCommand.id_housing_and_communal_services);
        }
    }
}
