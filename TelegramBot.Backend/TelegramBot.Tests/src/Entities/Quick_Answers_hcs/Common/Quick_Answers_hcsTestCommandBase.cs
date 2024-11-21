using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Persistence.src.Data;
using TelegramBot.Tests.src.Entities.Users.Common;

namespace TelegramBot.Tests.src.Entities.Quick_Answers_hcs.Common
{
    public class Quick_Answers_hcsTestCommandBase : IDisposable
    {
        protected readonly TelegramBotDbContext Context;

        public Quick_Answers_hcsTestCommandBase()
        {
            Context = Quick_Answers_hcsContextFactory.Create();
        }

        public void Dispose()
        {
            Quick_Answers_hcsContextFactory.Destroy(Context);
        }
    }
}
