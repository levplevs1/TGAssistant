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

namespace TelegramBot.Tests.src.Entities.Housing_And_Communal_Services.Common
{
    public class Housing_And_Communal_ServicesQueryTestFixture : IDisposable
    {
        public TelegramBotDbContext Context;
        public IMapper Mapper;

        public Housing_And_Communal_ServicesQueryTestFixture()
        {
            Context = Housing_And_Communal_ServicesContextFactory.Create();
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
            Housing_And_Communal_ServicesContextFactory.Destroy(Context);
        }
    }

    [CollectionDefinition("Housing_And_Communal_ServicesQueryCollection")]
    public class QueryCollection : ICollectionFixture<Housing_And_Communal_ServicesQueryTestFixture> { }
}
