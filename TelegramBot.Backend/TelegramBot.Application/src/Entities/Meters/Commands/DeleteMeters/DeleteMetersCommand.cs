using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Meters.Commands.DeleteMeters
{
    public class DeleteMetersCommand : IRequest
    {
        public int id_meters {  get; set; }
    }
}
