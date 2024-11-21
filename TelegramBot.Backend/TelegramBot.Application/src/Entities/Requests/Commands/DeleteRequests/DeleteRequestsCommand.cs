using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Requests.Commands.DeleteRequests
{
    public class DeleteRequestsCommand : IRequest
    {
        public int id_requests { get; set; }
    }
}
