using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Quick_Answers_Transport.Commands.UpdateQuick_Answers_Transport
{
    public class UpdateQuick_Answers_TransportCommandValidator : AbstractValidator<UpdateQuick_Answers_TransportCommand>
    {
        public UpdateQuick_Answers_TransportCommandValidator()
        {
            RuleFor(updateEntityCommand =>
            updateEntityCommand.quick_answer_transport_name).MaximumLength(250);
        }
    }
}
