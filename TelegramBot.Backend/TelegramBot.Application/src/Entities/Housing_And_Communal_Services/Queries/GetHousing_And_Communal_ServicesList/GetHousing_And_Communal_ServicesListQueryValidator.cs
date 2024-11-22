using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Housing_And_Communal_Services.Queries.GetHousing_And_Communal_ServicesList
{
    public class GetHousing_And_Communal_ServicesListQueryValidator : AbstractValidator<GetHousing_And_Communal_ServicesListQuery>
    {
        public GetHousing_And_Communal_ServicesListQueryValidator()
        {
            RuleFor(entity => entity.id_housing_and_communal_services);
        }
    }
}
