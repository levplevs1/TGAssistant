using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Meter_Readings.Commands.CreateMeter_Readings
{
    public class CreateMeter_ReadingsCommand : IRequest<int>
    {
        public string readings_value { get; set; }
        public string previos_readings_value { get; set; }
        public DateTime readings_date { get; set; }
        public int id_meters { get; set; }
        public int id_housing_and_communal_services { get; set; }
    }
}
