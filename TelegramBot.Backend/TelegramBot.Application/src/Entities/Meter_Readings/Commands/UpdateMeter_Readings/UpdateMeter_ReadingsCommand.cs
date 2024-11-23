using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Meter_Readings.Commands.UpdateMeter_Readings
{
    public class UpdateMeter_ReadingsCommand : IRequest
    {
        public int id_meter_readings { get; set; }
        public string readings_value { get; set; }
        public string previos_readings_value { get; set; }
    }
}
