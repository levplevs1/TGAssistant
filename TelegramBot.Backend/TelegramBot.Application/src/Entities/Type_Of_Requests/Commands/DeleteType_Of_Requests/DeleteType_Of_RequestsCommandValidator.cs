using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Type_Of_Requests.Commands.DeleteType_Of_Requests
{
    public class DeleteType_Of_RequestsCommandValidator : AbstractValidator<DeleteType_Of_RequestsCommand>
    {
        public DeleteType_Of_RequestsCommandValidator()
        {
            RuleFor(deleteEntityCommand => deleteEntityCommand.id_type_of_requests).NotEmpty();
        }
    }
}
