using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Transport.Commands.DeleteTransport
{
    public class DeleteTransportCommand : IRequest
    {
        public int id_transport {  get; set; }
    }
}
