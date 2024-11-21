using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Entities.Users.Commands.DeleteUsers;

namespace TelegramBot.Application.src.Entities.User_Memory.Commands.DeleteUser_Memory
{
    public class DeleteUser_MemoryCommandValidator : AbstractValidator<DeleteUser_MemoryCommand>
    {
        public DeleteUser_MemoryCommandValidator()
        {
            RuleFor(deleteEntityCommand => deleteEntityCommand.id_user_memory).NotEmpty();
        }
    }
}
