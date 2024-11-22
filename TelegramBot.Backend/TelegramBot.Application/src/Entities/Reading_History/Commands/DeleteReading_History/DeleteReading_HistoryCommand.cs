using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Reading_History.Commands.DeleteReading_History
{
    public class DeleteReading_HistoryCommand : IRequest
    {
        public int id_reading_history {  get; set; }
    }
}
