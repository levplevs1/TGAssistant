using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Requests.Commands.UpdateRequests
{
    public class UpdateRequestsCommandValidator : AbstractValidator<UpdateRequestsCommand>
    {
        public UpdateRequestsCommandValidator()
        {
            RuleFor(updateEntityCommand =>
            updateEntityCommand.request_text).MaximumLength(250);
            RuleFor(updateEntityCommand =>
            updateEntityCommand.response).MaximumLength(250);
        }
    }
}
