using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Persistence.src.Data;
using TelegramBot.Tests.src.Entities.Users.Common;

namespace TelegramBot.Tests.src.Entities.Service_Type.Common
{
    public class Service_TypeTestCommandBase : IDisposable
    {
        protected readonly TelegramBotDbContext Context;

        public Service_TypeTestCommandBase()
        {
            Context = Service_TypeContextFactory.Create();
        }

        public void Dispose()
        {
            Service_TypeContextFactory.Destroy(Context);
        }
    }
}
