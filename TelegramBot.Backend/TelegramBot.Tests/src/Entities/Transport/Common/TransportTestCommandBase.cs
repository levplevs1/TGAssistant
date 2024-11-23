using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Persistence.src.Data;
using TelegramBot.Tests.src.Entities.Users.Common;

namespace TelegramBot.Tests.src.Entities.Transport.Common
{
    public abstract class TransportTestCommandBase : IDisposable
    {
        protected readonly TelegramBotDbContext Context;

        public TransportTestCommandBase()
        {
            Context = TransportContextFactory.Create();
        }

        public void Dispose()
        {
            TransportContextFactory.Destroy(Context);
        }
    }
}
