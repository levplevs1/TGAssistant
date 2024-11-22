using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Housing_And_Communal_Services.Queries.GetHousing_And_Communal_ServicesList
{
    public class Housing_And_Communal_ServicesListVm
    {
        public IList<Housing_And_Communal_ServicesLookupDto> Housing_And_Communal_Services {  get; set; }
    }
}
