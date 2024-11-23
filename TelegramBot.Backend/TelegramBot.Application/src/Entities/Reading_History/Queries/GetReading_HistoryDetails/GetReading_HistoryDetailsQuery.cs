using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Reading_History.Queries.GetReading_HistoryDetails
{
    public class GetReading_HistoryDetailsQuery : IRequest<Reading_HistoryDetailsVm>
    {
        public int id_reading_history {  get; set; }
    }
}
