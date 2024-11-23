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

namespace TelegramBot.Tests.src.Entities.Meters.Common
{
    public class MetersQueryTestFixture : IDisposable
    {
        public TelegramBotDbContext Context;
        public IMapper Mapper;

        public MetersQueryTestFixture()
        {
            Context = MetersContextFactory.Create();
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
            MetersContextFactory.Destroy(Context);
        }
    }

    [CollectionDefinition("MetersQueryCollection")]
    public class QueryCollection : ICollectionFixture<MetersQueryTestFixture> { }
}
