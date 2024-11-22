using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Persistence.src.Data;
using TelegramBot.Tests.src.Entities.Users.Common;

namespace TelegramBot.Tests.src.Entities.Payments.Common
{
    public class PaymentsTestCommandBase : IDisposable
    {
        protected readonly TelegramBotDbContext Context;

        public PaymentsTestCommandBase()
        {
            Context = PaymentsContextFactory.Create();
        }

        public void Dispose()
        {
            PaymentsContextFactory.Destroy(Context);
        }
    }
}
