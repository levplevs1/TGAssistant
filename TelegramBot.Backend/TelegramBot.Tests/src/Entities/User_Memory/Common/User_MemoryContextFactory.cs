using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Persistence.src.Data;

namespace TelegramBot.Tests.src.Entities.User_Memory.Common
{
    public class User_MemoryContextFactory
    {
        public static int id_user_memory_for_delete = 3;
        public static int id_user_memory_for_update = 4;

        public static TelegramBotDbContext Create()
        {
            var options = new DbContextOptionsBuilder<TelegramBotDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new TelegramBotDbContext(options);
            context.Database.EnsureCreated();
            context.User_Memory.AddRange(
                new Domain.src.Entities.User_Memory
                {
                    id_user_memory = 1,
                    content_memory = "Transport",
                    id_users = 1
                },

                new Domain.src.Entities.User_Memory
                {
                    id_user_memory = 2,
                    content_memory = "Auto",
                    id_users = 2
                },

                new Domain.src.Entities.User_Memory

                {
                    id_user_memory = id_user_memory_for_delete,
                    content_memory = "Fill",
                    id_users = 3
                },

                new Domain.src.Entities.User_Memory
                {
                    id_user_memory = id_user_memory_for_update,
                    content_memory = "Care",
                    id_users = 4
                }
            );
            context.SaveChanges();
            return context;
        }

        public static void Destroy(TelegramBotDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}
