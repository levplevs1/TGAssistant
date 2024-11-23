using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Persistence.src.Data;

namespace TelegramBot.Tests.src.Entities.Meter_Type.Common
{
    public class Meter_TypeTestCommandBase : IDisposable
    {
        protected readonly TelegramBotDbContext Context;

        public Meter_TypeTestCommandBase()
        {
            Context = Meter_TypeContextFactory.Create();
        }

        public void Dispose()
        {
            Meter_TypeContextFactory.Destroy(Context);
        }
    }
}
