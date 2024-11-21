using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Reading_History.Queries.GetReading_HistoryList
{
    public class Reading_HistoryListVm
    {
        public IList<Reading_HistoryLookupDto> Reading_History {  get; set; }
    }
}
