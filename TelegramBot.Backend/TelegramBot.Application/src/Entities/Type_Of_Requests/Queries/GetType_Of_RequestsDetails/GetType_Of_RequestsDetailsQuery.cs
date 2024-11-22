using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Type_Of_Requests.Queries.GetType_Of_RequestsDetails
{
    public class GetType_Of_RequestsDetailsQuery : IRequest<Type_Of_RequestsDetailsVm>
    {
        public int id_type_of_requests { get; set; }
    }
}
