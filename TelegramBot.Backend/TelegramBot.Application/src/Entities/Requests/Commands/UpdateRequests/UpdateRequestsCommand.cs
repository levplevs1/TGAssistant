using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Domain.src.Entities;

namespace TelegramBot.Application.src.Entities.Requests.Commands.UpdateRequests
{
    public class UpdateRequestsCommand : IRequest
    {
        public int id_requests { get; set; }
        public string request_text { get; set; }
        public string response { get; set; }
    }
}
