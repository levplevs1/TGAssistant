using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Persistence.src.Data;
using TelegramBot.Tests.src.Entities.Users.Common;

namespace TelegramBot.Tests.src.Entities.Housing_And_Communal_Services.Common
{
    public class Housing_And_Communal_ServicesTestCommandBase : IDisposable
    {
        protected readonly TelegramBotDbContext Context;

        public Housing_And_Communal_ServicesTestCommandBase()
        {
            Context = Housing_And_Communal_ServicesContextFactory.Create();
        }

        public void Dispose()
        {
            Housing_And_Communal_ServicesContextFactory.Destroy(Context);
        }
    }
}
