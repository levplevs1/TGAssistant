using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Service_Type.Queries.GetService_TypeDetails
{
    public class GetService_TypeDetailsQuery : IRequest<Service_TypeDetailsVm>
    {
        public int id_service_type { get; set; }
    }
}
