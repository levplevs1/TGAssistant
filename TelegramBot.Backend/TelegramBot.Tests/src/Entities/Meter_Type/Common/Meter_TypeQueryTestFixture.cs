using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Common.Mapping;
using TelegramBot.Application.src.Interfaces;
using TelegramBot.Persistence.src.Data;
using TelegramBot.Tests.src.Entities.Users.Common;

namespace TelegramBot.Tests.src.Entities.Meter_Type.Common
{
    public class Meter_TypeQueryTestFixture : IDisposable
    {
        public TelegramBotDbContext Context;
        public IMapper Mapper;

        public Meter_TypeQueryTestFixture()
        {
            Context = Meter_TypeContextFactory.Create();
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

    [CollectionDefinition("Meter_TypeQueryCollection")]
    public class QueryCollection : ICollectionFixture<Meter_TypeQueryTestFixture> { }
}
