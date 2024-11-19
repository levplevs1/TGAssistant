using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Persistence.src.Data
{
    public class DbInitializer
    {
        public static void Initialize(TelegramBotDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
