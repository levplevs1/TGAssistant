using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Persistence.src.Data;
using TelegramBot.Tests.src.Entities.Users.Common;

namespace TelegramBot.Tests.src.Entities.Meter_Readings.Common
{
    public abstract class Meter_ReadingsTestCommandBase : IDisposable
    {
        protected readonly TelegramBotDbContext Context;

        public Meter_ReadingsTestCommandBase()
        {
            Context = Meter_ReadingsContextFactory.Create();
        }

        public void Dispose()
        {
            Meter_ReadingsContextFactory.Destroy(Context);
        }
    }
}
