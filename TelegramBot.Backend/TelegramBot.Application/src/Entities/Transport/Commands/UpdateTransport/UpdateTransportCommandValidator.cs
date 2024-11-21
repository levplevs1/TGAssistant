using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Transport.Commands.UpdateTransport
{
    public class UpdateTransportCommandValidator : AbstractValidator<UpdateTransportCommand>
    {
        public UpdateTransportCommandValidator()
        {
            RuleFor(updateEntityCommand =>
            updateEntityCommand.text_of_request).MaximumLength(250);
        }
    }
}
