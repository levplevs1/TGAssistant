using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Persistence.src.Data;

namespace TelegramBot.Tests.src.Entities.Users.Common
{
    public abstract class UsersTestCommandBase : IDisposable
    {
        protected readonly TelegramBotDbContext Context;

        public UsersTestCommandBase()
        {
            Context = UsersContextFactory.Create();
        }

        public void Dispose()
        {
            UsersContextFactory.Destroy(Context);
        }
    }
}
