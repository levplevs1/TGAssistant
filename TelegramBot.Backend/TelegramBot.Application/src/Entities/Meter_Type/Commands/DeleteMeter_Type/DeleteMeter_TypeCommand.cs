using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Meter_Type.Commands.DeleteMeter_Type
{
    public class DeleteMeter_TypeCommand : IRequest
    {
        public int id_meter_type {  get; set; }
    }
}
