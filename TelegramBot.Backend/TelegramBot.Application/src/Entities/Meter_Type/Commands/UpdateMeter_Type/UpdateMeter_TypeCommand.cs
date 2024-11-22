using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Meter_Type.Commands.UpdateMeter_Type
{
    public class UpdateMeter_TypeCommand : IRequest
    {
        public int id_meter_type {  get; set; }
        public string meter_type_name { get; set; }
    }
}
