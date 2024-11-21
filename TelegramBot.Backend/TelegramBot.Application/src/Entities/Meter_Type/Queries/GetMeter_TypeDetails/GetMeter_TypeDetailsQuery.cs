using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Meter_Type.Queries.GetMeter_TypeDetails
{
    public class GetMeter_TypeDetailsQuery : IRequest<Meter_TypeDetailsVm>
    {
        public int id_meter_type {  get; set; }
    }
}
