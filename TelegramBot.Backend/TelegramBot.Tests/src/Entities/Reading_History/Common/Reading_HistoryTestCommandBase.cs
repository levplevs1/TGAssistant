using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Persistence.src.Data;
using TelegramBot.Tests.src.Entities.Users.Common;

namespace TelegramBot.Tests.src.Entities.Reading_History.Common
{
    public class Reading_HistoryTestCommandBase : IDisposable
    {
        protected readonly TelegramBotDbContext Context;

        public Reading_HistoryTestCommandBase()
        {
            Context = Reading_HistoryContextFactory.Create();
        }

        public void Dispose()
        {
            Reading_HistoryContextFactory.Destroy(Context);
        }
    }
}
