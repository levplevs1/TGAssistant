using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Entities.Requests.Commands.CreateRequest;

namespace TelegramBot.Application.src.Entities.Requests.Commands.CreateRequests
{
    public class CreateRequestsCommandValidator : AbstractValidator<CreateRequestsCommand>
    {
        public CreateRequestsCommandValidator()
        {
            RuleFor(createEntityCommand =>
            createEntityCommand.request_text).MaximumLength(250);
            RuleFor(createEntityCommand =>
            createEntityCommand.response).MaximumLength(250);
            RuleFor(createEntityCommand =>
            createEntityCommand.created_at);
            RuleFor(createEntityCommand =>
            createEntityCommand.id_type_of_requests);
            RuleFor(createEntityCommand =>
            createEntityCommand.id_users);
        }
    }
}
