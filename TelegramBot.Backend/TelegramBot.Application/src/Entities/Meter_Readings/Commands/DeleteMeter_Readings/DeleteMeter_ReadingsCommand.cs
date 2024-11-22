using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Meter_Readings.Commands.DeleteMeter_Readings
{
    public class DeleteMeter_ReadingsCommand : IRequest
    {
        public int id_meter_readings { get; set; }
    }
}
