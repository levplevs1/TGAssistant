using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Persistence.src.Data;
using TelegramBot.Tests.src.Entities.Users.Common;

namespace TelegramBot.Tests.src.Entities.Quick_Answers_Healthcare.Common
{
    public abstract class Quick_Answers_HealthcareTestCommandBase
         : IDisposable
    {
        protected readonly TelegramBotDbContext Context;

        public Quick_Answers_HealthcareTestCommandBase()
        {
            Context = Quick_Answers_HealthcareContextFactory.Create();
        }

        public void Dispose()
        {
            Quick_Answers_HealthcareContextFactory.Destroy(Context);
        }
    }
}
