using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Transport.Commands.UpdateTransport
{
    public class UpdateTransportCommand : IRequest
    {
        public int id_transport { get; set; }
        public string text_of_request { get; set; }
    }
}
