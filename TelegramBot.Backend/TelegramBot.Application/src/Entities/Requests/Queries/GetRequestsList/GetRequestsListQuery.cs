using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Entities.Requests.Queries.GetRequestsList;

namespace TelegramBot.Application.src.Entities.Requests.Queries.GetRequestList
{
    public class GetRequestsListQuery : IRequest<RequestsListVm>
    {
        public int id_requests {  get; set; }
    }
}
