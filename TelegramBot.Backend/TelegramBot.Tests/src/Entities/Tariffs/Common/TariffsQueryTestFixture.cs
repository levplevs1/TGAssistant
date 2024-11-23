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

namespace TelegramBot.Tests.src.Entities.Tariffs.Common
{
    public class TariffsQueryTestFixture : IDisposable
    {
        public TelegramBotDbContext Context;
        public IMapper Mapper;

        public TariffsQueryTestFixture()
        {
            Context = TariffsContextFactory.Create();
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
            TariffsContextFactory.Destroy(Context);
        }
    }

    [CollectionDefinition("TariffsQueryCollection")]
    public class QueryCollection : ICollectionFixture<TariffsQueryTestFixture> { }
}
