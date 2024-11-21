using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Quick_Answers_Transport.Commands.CreateQuick_Answers_Transport
{
    public class CreateQuick_Answers_TransportCommandValidator : AbstractValidator<CreateQuick_Answers_TransportCommand>
    {
        public CreateQuick_Answers_TransportCommandValidator()
        {
            RuleFor(createEntityCommand =>
            createEntityCommand.id_transport);
            RuleFor(createEntityCommand =>
            createEntityCommand.quick_answer_transport_name).MaximumLength(250);
        }
    }
}
