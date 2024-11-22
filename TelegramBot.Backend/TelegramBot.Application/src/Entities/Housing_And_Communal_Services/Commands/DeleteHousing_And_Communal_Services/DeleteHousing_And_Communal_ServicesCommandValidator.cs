using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Housing_And_Communal_Services.Commands.DeleteHousing_And_Communal_Services
{
    public class DeleteHousing_And_Communal_ServicesCommandValidator : AbstractValidator<DeleteHousing_And_Communal_ServicesCommand>
    {
        public DeleteHousing_And_Communal_ServicesCommandValidator()
        {
            RuleFor(deleteEntityCommand => deleteEntityCommand.id_housing_and_communal_services).NotEmpty();
        }
    }
}
