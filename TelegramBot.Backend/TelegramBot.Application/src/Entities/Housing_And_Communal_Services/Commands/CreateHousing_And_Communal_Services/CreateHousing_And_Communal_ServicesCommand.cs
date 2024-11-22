using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Housing_And_Communal_Services.Commands.CreateHousing_And_Communal_Services
{
    public class CreateHousing_And_Communal_ServicesCommand : IRequest<int>
    {
        public string text_of_request { get; set; }
        public DateTime created_at { get; set; }
    }
}
