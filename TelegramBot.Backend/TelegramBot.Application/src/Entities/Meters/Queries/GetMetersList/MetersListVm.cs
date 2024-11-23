using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Meters.Queries.GetMetersList
{
    public class MetersListVm
    {
        public IList<MetersLookupDto> Meters { get; set; }
    }
}
