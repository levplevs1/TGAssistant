using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Persistence.src.Data;
using TelegramBot.Tests.src.Entities.Users.Common;

namespace TelegramBot.Tests.src.Entities.Education.Common
{
    public abstract class EducationTestCommandBase : IDisposable
    {
        protected readonly TelegramBotDbContext Context;

        public EducationTestCommandBase()
        {
            Context = EducationContextFactory.Create();
        }

        public void Dispose()
        {
            EducationContextFactory.Destroy(Context);
        }
    }
}
