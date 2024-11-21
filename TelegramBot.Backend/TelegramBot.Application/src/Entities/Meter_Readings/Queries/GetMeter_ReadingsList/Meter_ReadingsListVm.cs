using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Meter_Readings.Queries.GetMeter_ReadingsList
{
    public class Meter_ReadingsListVm
    {
        public IList<Meter_ReadingsLookupDto> Meter_Readings {  get; set; }
    }
}
