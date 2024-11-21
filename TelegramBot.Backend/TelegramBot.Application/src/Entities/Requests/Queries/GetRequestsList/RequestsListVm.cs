using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Requests.Queries.GetRequestsList
{
    public class RequestsListVm
    {
        public IList<RequestsLookupDto> Requests {  get; set; }
    }
}
