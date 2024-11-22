using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Persistence.src.Data;

namespace TelegramBot.Tests.src.Entities.User_Memory.Common
{
    public abstract class User_MemoryTestCommandBase : IDisposable
    {
        protected readonly TelegramBotDbContext Context;

        public User_MemoryTestCommandBase()
        {
            Context = User_MemoryContextFactory.Create();
        }

        public void Dispose()
        {
            User_MemoryContextFactory.Destroy(Context);
        }
    }
}
