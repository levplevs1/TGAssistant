using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Meters.Queries.GetMetersList
{
    public class GetMetersListQuery : IRequest<MetersListVm>
    {
        public int id_meters {  get; set; }
    }
}
