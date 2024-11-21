using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Persistence.src.Data;
using TelegramBot.Tests.src.Entities.Users.Common;

namespace TelegramBot.Tests.src.Entities.Tariffs.Common
{
    public class TariffsTestCommandBase : IDisposable
    {
        protected readonly TelegramBotDbContext Context;

        public TariffsTestCommandBase()
        {
            Context = TariffsContextFactory.Create();
        }

        public void Dispose()
        {
            TariffsContextFactory.Destroy(Context);
        }
    }
}
