using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Meter_Type.Queries.GetMeter_TypeList
{
    public class GetMeter_TypeListQuery : IRequest<Meter_TypeListVm>
    {
        public int id_meter_type { get; set; }
    }
}
