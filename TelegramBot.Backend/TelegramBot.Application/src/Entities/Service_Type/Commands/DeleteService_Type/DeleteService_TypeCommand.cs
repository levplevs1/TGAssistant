using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Service_Type.Commands.DeleteService_Type
{
    public class DeleteService_TypeCommand : IRequest
    {
        public int id_service_type { get; set; }
    }
}
