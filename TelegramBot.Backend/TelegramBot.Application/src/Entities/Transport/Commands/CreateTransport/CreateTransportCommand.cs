using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Transport.Commands.CreateTransport
{
    public class CreateTransportCommand : IRequest<int>
    {
        public string text_of_request { get; set; }
        public DateTime created_at { get; set; }
    }
}
