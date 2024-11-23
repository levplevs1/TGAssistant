using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Meter_Type.Commands.CreateMeter_Type
{
    public class CreateMeter_TypeCommand : IRequest<int>
    {
        public string meter_type_name { get; set; }
    }
}
