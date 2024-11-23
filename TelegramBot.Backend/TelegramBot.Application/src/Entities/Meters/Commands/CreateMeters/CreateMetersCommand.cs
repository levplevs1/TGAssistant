using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Meters.Commands.CreateMeters
{
    public class CreateMetersCommand : IRequest<int>
    {
        public DateTime instalition_date { get; set; }
        public DateTime? last_reading_date { get; set; }
        public int id_meter_type { get; set; }
        public int id_users { get; set; }
    }
}
