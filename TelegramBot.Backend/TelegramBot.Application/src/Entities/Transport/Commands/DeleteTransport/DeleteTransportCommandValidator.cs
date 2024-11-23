using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Transport.Commands.DeleteTransport
{
    public class DeleteTransportCommandValidator : AbstractValidator<DeleteTransportCommand>
    {
        public DeleteTransportCommandValidator()
        {
            RuleFor(deleteEntityCommand => deleteEntityCommand.id_transport).NotEmpty();
        }
    }
}
