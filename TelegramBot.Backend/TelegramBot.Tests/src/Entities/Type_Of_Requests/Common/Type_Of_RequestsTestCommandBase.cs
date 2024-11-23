using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Persistence.src.Data;
using TelegramBot.Tests.src.Entities.Users.Common;

namespace TelegramBot.Tests.src.Entities.Type_Of_Requests.Common
{
    public abstract class Type_Of_RequestsTestCommandBase : IDisposable
    {
        protected readonly TelegramBotDbContext Context;

        public Type_Of_RequestsTestCommandBase()
        {
            Context = Type_Of_RequestsContextFactory.Create();
        }

        public void Dispose()
        {
            Type_Of_RequestsContextFactory.Destroy(Context);
        }
    }
}
