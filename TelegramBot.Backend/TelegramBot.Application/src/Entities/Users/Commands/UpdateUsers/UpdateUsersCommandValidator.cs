using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Users.Commands.UpdateUsers
{
    public class UpdateUsersCommandValidator : AbstractValidator<UpdateUsersCommand>
    {
        public UpdateUsersCommandValidator()
        {
            RuleFor(createEntityCommand =>
            createEntityCommand.name).MaximumLength(250);
            RuleFor(createEntityCommand =>
            createEntityCommand.lastname).MaximumLength(250);
            RuleFor(createEntityCommand =>
            createEntityCommand.username).MaximumLength(250);
        }
    }
}
