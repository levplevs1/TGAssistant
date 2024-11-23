using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Service_Type.Commands.UpdateService_Type
{
    public class UpdateService_TypeCommand : IRequest
    {
        public int id_service_type { get; set; }
        public string service_type_name { get; set; }
        public int? id_housing_and_communal_services { get; set; }
    }
}
