using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Persistence.src.Data;
using TelegramBot.Tests.src.Entities.Users.Common;

namespace TelegramBot.Tests.src.Entities.Meters.Common
{
    public class MetersTestCommandBase : IDisposable
    {
        protected readonly TelegramBotDbContext Context;

        public MetersTestCommandBase()
        {
            Context = MetersContextFactory.Create();
        }

        public void Dispose()
        {
            MetersContextFactory.Destroy(Context);
        }
    }
}
