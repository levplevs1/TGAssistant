using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Transport.Queries.GetTransportList
{
    public class GetTransportListQuery : IRequest<TransportListVm>
    {
        public int id_transport {  get; set; }
    }
}
