using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Meters.Commands.UpdateMeters
{
    public class UpdateMetersCommand : IRequest
    {
        public int id_meters { get; set; }
        public DateTime? last_reading_date { get; set; }
        public int id_meter_type { get; set; }
        public int id_users { get; set; }
    }
}
