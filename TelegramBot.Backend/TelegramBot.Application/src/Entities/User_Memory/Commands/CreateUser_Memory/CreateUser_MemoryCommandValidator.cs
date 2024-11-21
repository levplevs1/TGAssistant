using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.User_Memory.Commands.CreateUser_Memory
{
    public class CreateUser_MemoryCommandValidator : AbstractValidator<CreateUser_MemoryCommand>
    {
        public CreateUser_MemoryCommandValidator()
        {
            RuleFor(createEntityCommand =>
            createEntityCommand.content_memory).MaximumLength(250);
            RuleFor(createEntityCommand =>
            createEntityCommand.id_users);
        }
    }
}
