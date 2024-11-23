using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Service_Type.Commands.DeleteService_Type
{
    public class DeleteService_TypeCommandValidator : AbstractValidator<DeleteService_TypeCommand>
    {
        public DeleteService_TypeCommandValidator()
        {
            RuleFor(deleteEntityCommand => deleteEntityCommand.id_service_type).NotEmpty();
        }
    }
}
