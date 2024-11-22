using MediatR;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Reading_History.Queries.GetReading_HistoryList
{
    public class GetReading_HistoryListQuery : IRequest<Reading_HistoryListVm>
    {
        public int id_reading_history {  get; set; }
    }
}
