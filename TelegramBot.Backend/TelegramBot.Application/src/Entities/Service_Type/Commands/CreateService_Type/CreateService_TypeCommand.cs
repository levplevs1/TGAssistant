using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Service_Type.Commands.CreateService_Type
{
    public class CreateService_TypeCommand : IRequest<int>
    {
        public string service_type_name { get; set; }
        public int id_housing_and_communal_services { get; set; }
    }
}
