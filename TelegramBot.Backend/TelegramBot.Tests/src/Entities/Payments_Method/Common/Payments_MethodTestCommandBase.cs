using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Persistence.src.Data;
using TelegramBot.Tests.src.Entities.Users.Common;

namespace TelegramBot.Tests.src.Entities.Payments_Method.Common
{
    public class Payments_MethodTestCommandBase : IDisposable
    {
        protected readonly TelegramBotDbContext Context;

        public Payments_MethodTestCommandBase()
        {
            Context = Payments_MethodContextFactory.Create();
        }

        public void Dispose()
        {
            Payments_MethodContextFactory.Destroy(Context);
        }
    }
}
