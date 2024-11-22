using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Meter_Type.Queries.GetMeter_TypeList
{
    public class Meter_TypeListVm
    {
        public IList<Meter_TypeLookupDto> Meter_Type {  get; set; }
    }
}
