using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Requests.Commands.DeleteRequests
{
    public class DeleteRequestsCommandValidator : AbstractValidator<DeleteRequestsCommand>
    {
        public DeleteRequestsCommandValidator()
        {
            RuleFor(deleteEntityCommand => deleteEntityCommand.id_requests).NotEmpty();
        }
    }
}
