using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Persistence.src.Data;
using TelegramBot.Tests.src.Entities.Users.Common;

namespace TelegramBot.Tests.src.Entities.Healthcare.Common
{
    public abstract class HealthcareTestCommandBase : IDisposable
    {
        protected readonly TelegramBotDbContext Context;

        public HealthcareTestCommandBase()
        {
            Context = HealthcareContextFactory.Create();
        }

        public void Dispose()
        {
            HealthcareContextFactory.Destroy(Context);
        }
    }
}
