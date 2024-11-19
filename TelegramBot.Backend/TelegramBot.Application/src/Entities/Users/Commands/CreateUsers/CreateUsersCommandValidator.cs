using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Users.Commands.CreateUsers
{
    public class CreateUsersCommandValidator : AbstractValidator<CreateUsersCommand>
    {
        public CreateUsersCommandValidator()
        {
            RuleFor(createEntityCommand =>
            createEntityCommand.id_telegram);
            RuleFor(createEntityCommand =>
            createEntityCommand.name).MaximumLength(250);
            RuleFor(createEntityCommand =>
            createEntityCommand.lastname).MaximumLength(250);
            RuleFor(createEntityCommand =>
            createEntityCommand.username).MaximumLength(250);
            RuleFor(createEntityCommand =>
            createEntityCommand.created_at);
        }
    }
}
