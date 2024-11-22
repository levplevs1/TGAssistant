using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Transport.Commands.CreateTransport
{
    public class CreateTransportCommandValidator : AbstractValidator<CreateTransportCommand>
    {
        public CreateTransportCommandValidator()
        {
            RuleFor(createEntityCommand =>
            createEntityCommand.text_of_request).MaximumLength(250);
            RuleFor(createEntityCommand =>
            createEntityCommand.created_at);
        }
    }
}
