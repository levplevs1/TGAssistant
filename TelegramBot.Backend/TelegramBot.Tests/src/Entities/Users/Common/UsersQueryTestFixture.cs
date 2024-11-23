using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Common.Mapping;
using TelegramBot.Application.src.Interfaces;
using TelegramBot.Persistence.src.Data;

namespace TelegramBot.Tests.src.Entities.Users.Common
{
    public class UsersQueryTestFixture : IDisposable
    {
        public TelegramBotDbContext Context;
        public IMapper Mapper;

        public UsersQueryTestFixture()
        {
            Context = UsersContextFactory.Create();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AllowNullCollections = true;
                cfg.ShouldMapMethod = (m => false);
                cfg.AddProfile(new AssemblyMappingProfile(
                    typeof(ITelegramBotDbContext).Assembly));
            });
            Mapper = configurationProvider.CreateMapper();
        }

        public void Dispose()
        {
            UsersContextFactory.Destroy(Context);
        }
    }

    [CollectionDefinition("UsersQueryCollection")]
    public class QueryCollection : ICollectionFixture<UsersQueryTestFixture> { }
}
