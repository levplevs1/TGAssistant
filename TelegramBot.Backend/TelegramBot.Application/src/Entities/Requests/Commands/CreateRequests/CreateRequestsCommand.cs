using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Domain.src.Entities;

namespace TelegramBot.Application.src.Entities.Requests.Commands.CreateRequest
{
    public class CreateRequestsCommand : IRequest<int>
    {
        public string request_text { get; set; }
        public string response { get; set; }
        public DateTime created_at { get; set; }
        public int id_type_of_requests { get; set; }
        public int id_users { get; set; }
    }
}
