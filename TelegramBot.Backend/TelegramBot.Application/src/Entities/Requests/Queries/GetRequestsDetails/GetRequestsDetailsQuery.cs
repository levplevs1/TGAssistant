using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Entities.Requests.Queries.GetRequestsDetails;

namespace TelegramBot.Application.src.Entities.Requests.Queries.GetRequestsDetails
{
    public class GetRequestsDetailsQuery : IRequest<RequestsDetailsVm>
    {
        public int id_requests {  get; set; }
    }
}
