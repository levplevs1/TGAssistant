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

namespace TelegramBot.Tests.src.Entities.Service_Type.Common
{
    public class Service_TypeQueryTestFixture : IDisposable
    {
        public TelegramBotDbContext Context;
        public IMapper Mapper;

        public Service_TypeQueryTestFixture()
        {
            Context = Service_TypeContextFactory.Create();
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
            Service_TypeContextFactory.Destroy(Context);
        }
    }

    [CollectionDefinition("Service_TypeQueryCollection")]
    public class QueryCollection : ICollectionFixture<Service_TypeQueryTestFixture> { }
}
