using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Housing_And_Communal_Services.Queries.GetHousing_And_Communal_ServicesDetails
{
    public class GetHousing_And_Communal_ServicesDetailsQuery : IRequest<Housing_And_Communal_ServicesDetailsVm>
    {
        public int id_housing_and_communal_services { get; set; }
    }
}
