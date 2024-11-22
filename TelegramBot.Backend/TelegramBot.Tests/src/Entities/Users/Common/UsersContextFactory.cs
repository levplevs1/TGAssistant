using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Persistence.src.Data;

namespace TelegramBot.Tests.src.Entities.Users.Common
{
    public class UsersContextFactory
    {
        public static int id_users_for_delete = 3;
        public static int id_users_for_update = 4;

        public static TelegramBotDbContext Create()
        {
            var options = new DbContextOptionsBuilder<TelegramBotDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new TelegramBotDbContext(options);
            context.Database.EnsureCreated();
            context.Users.AddRange(
                new Domain.src.Entities.Users
                {
                    id_users = 1,
                    id_telegram = 1,
                    name = "Ivan",
                    lastname = "Ivanov",
                    username = "Ivanushka",
                    created_at = DateTime.Today
                },

                new Domain.src.Entities.Users
                {
                    id_users = 2,
                    id_telegram = 2,
                    name = "Kirill",
                    lastname = "Kirillov",
                    username = "Kirusha",
                    created_at = DateTime.Today
                },

                new Domain.src.Entities.Users

                {
                    id_users = id_users_for_delete,
                    id_telegram = 4,
                    name = "Artem",
                    lastname = "Artemov",
                    username = "Artemushka",
                    created_at = DateTime.Today
                },

                new Domain.src.Entities.Users
                {
                    id_users = id_users_for_update,
                    id_telegram = 4,
                    name = "Sergey",
                    lastname = "Sergeev",
                    username = "Seriy",
                    created_at = DateTime.Today
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
