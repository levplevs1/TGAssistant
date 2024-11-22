using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Meter_Readings.Queries.GetMeter_ReadingsList
{
    public class GetMeter_ReadingsListQuery : IRequest<Meter_ReadingsListVm>
    {
        public int id_meter_readings {  get; set; }
    }
}
