using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Persistence.src.Data;
using TelegramBot.Tests.src.Entities.Users.Common;

namespace TelegramBot.Tests.src.Entities.Requests.Common
{
    public abstract class RequestsTestCommandBase : IDisposable
    {
        protected readonly TelegramBotDbContext Context;

        public RequestsTestCommandBase()
        {
            Context = RequestsContextFactory.Create();
        }

        public void Dispose()
        {
            RequestsContextFactory.Destroy(Context);
        }
    }
}
