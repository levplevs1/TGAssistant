using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Housing_And_Communal_Services.Queries.GetHousing_And_Communal_ServicesList
{
    public class GetHousing_And_Communal_ServicesListQuery : IRequest<Housing_And_Communal_ServicesListVm>
    {
        public int id_housing_and_communal_services { get; set; }
    }
}
