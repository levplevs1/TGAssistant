using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Meter_Readings.Queries.GetMeter_ReadingsDetails
{
    public class GetMeter_ReadingsDetailsQuery : IRequest<Meter_ReadingsDetailsVm>
    {
        public int id_meter_readings {  get; set; }
    }
}
