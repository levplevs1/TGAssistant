using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Reading_History.Commands.DeleteReading_History
{
    public class DeleteReading_HistoryCommandValidator : AbstractValidator<DeleteReading_HistoryCommand>
    {
        public DeleteReading_HistoryCommandValidator()
        {
            RuleFor(deleteEntityCommand => deleteEntityCommand.id_reading_history).NotEmpty();
        }
    }
}
