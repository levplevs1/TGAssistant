using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Users.Commands.DeleteUsers
{
    public class DeleteUsersCommandValidator : AbstractValidator<DeleteUsersCommand>
    {
        public DeleteUsersCommandValidator()
        {
            RuleFor(deleteEntityCommand => deleteEntityCommand.id_users).NotEmpty();
        }
    }
}
