using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.User_Memory.Commands.UpdateUser_Memory
{
    public class UpdateUser_MemoryCommandValidator : AbstractValidator<UpdateUser_MemoryCommand>  
    {
        public UpdateUser_MemoryCommandValidator()
        {
            RuleFor(updateEntityCommand =>
            updateEntityCommand.content_memory).MaximumLength(250);
        }
    }
}
