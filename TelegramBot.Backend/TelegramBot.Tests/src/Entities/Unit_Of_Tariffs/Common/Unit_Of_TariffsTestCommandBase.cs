using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Persistence.src.Data;
using TelegramBot.Tests.src.Entities.Users.Common;

namespace TelegramBot.Tests.src.Entities.Unit_Of_Tariffs.Common
{
    public class Unit_Of_TariffsTestCommandBase : IDisposable
    {
        protected readonly TelegramBotDbContext Context;

        public Unit_Of_TariffsTestCommandBase()
        {
            Context = Unit_Of_TariffsContextFactory.Create();
        }

        public void Dispose()
        {
            Unit_Of_TariffsContextFactory.Destroy(Context);
        }
    }
}
