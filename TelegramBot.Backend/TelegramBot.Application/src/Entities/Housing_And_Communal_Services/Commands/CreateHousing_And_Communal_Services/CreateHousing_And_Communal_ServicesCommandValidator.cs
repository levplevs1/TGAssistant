using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Housing_And_Communal_Services.Commands.CreateHousing_And_Communal_Services
{
    public class CreateHousing_And_Communal_ServicesCommandValidator : AbstractValidator<CreateHousing_And_Communal_ServicesCommand>
    {
        public CreateHousing_And_Communal_ServicesCommandValidator()
        {
            RuleFor(createEntityCommand =>
            createEntityCommand.created_at);
            RuleFor(createEntityCommand =>
            createEntityCommand.text_of_request).MaximumLength(250);
        }
    }
}
