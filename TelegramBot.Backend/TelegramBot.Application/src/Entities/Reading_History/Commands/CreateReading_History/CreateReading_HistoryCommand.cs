using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Reading_History.Commands.CreateReading_History
{
    public class CreateReading_HistoryCommand : IRequest<int>
    {
        public DateTime reading_date { get; set; }
        public string reading_value { get; set; }
        public int id_meters { get; set; }
        public int id_housing_and_communal_services { get; set; }
    }
}
