using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Reading_History.Commands.UpdateReading_History
{
    public class UpdateReading_HistoryCommand : IRequest
    {
        public int id_reading_history { get; set; }
        public string reading_value { get; set; }
    }
}
