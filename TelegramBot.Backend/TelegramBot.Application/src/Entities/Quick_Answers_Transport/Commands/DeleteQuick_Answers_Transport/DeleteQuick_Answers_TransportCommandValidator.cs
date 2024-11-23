using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Quick_Answers_Transport.Commands.DeleteQuick_Answers_Transport
{
    public class DeleteQuick_Answers_TransportCommandValidator : AbstractValidator<DeleteQuick_Answers_TransportCommand>
    {
        public DeleteQuick_Answers_TransportCommandValidator()
        {
            RuleFor(deleteEntityCommand => deleteEntityCommand.id_quick_answer_transport).NotEmpty();
        }
    }
}
