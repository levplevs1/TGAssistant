using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Type_Of_Requests.Commands.CreateType_Of_Requests
{
    public class CreateType_Of_RequestsCommand : IRequest<int>
    {
        public int? id_housing_and_communal_services { get; set; }
        public int? id_healthcare { get; set; }
        public int? id_transport { get; set; }
        public int? id_education { get; set; }
    }
}
