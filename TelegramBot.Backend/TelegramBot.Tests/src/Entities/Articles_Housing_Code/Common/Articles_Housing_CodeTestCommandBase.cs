using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Persistence.src.Data;
using TelegramBot.Tests.src.Entities.Users.Common;

namespace TelegramBot.Tests.src.Entities.Articles_Housing_Code.Common
{
    public abstract class Articles_Housing_CodeTestCommandBase : IDisposable
    {
        protected readonly TelegramBotDbContext Context;

        public Articles_Housing_CodeTestCommandBase()
        {
            Context = Articles_Housing_CodeContextFactory.Create();
        }

        public void Dispose()
        {
            Articles_Housing_CodeContextFactory.Destroy(Context);
        }
    }
}
