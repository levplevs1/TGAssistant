using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Transport.Queries.GetTransportDetails
{
    public class GetTransportDetailsQuery : IRequest<TransportDetailsVm>
    {
        public int id_transport {  get; set; }
    }
}
