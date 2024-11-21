using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Service_Type.Queries.GetService_TypeList
{
    public class GetService_TypeListQuery : IRequest<Service_TypeListVm>
    {
        public int id_service_type { get; set; }
    }
}
