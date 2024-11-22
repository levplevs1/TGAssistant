using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Housing_And_Communal_Services.Queries.GetHousing_And_Communal_ServicesDetails
{
    public class GetHousing_And_Communal_ServicesDetailsQueryValidator : AbstractValidator<GetHousing_And_Communal_ServicesDetailsQuery>
    {
        public GetHousing_And_Communal_ServicesDetailsQueryValidator()
        {
            RuleFor(entity => entity.id_housing_and_communal_services).NotEmpty();
        }
    }
}
