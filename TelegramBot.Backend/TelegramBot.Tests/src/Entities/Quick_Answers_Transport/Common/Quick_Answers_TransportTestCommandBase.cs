using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Persistence.src.Data;
using TelegramBot.Tests.src.Entities.Users.Common;

namespace TelegramBot.Tests.src.Entities.Quick_Answers_Transport.Common
{
    public abstract class Quick_Answers_TransportTestCommandBase : IDisposable
    {
        protected readonly TelegramBotDbContext Context;

        public Quick_Answers_TransportTestCommandBase()
        {
            Context = Quick_Answers_TransportContextFactory.Create();
        }

        public void Dispose()
        {
            Quick_Answers_TransportContextFactory.Destroy(Context);
        }
    }
}
