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

namespace TelegramBot.Tests.src.Entities.Type_Of_Requests.Common
{
    public class Type_Of_RequestsQueryTestFixture : IDisposable
    {
        public TelegramBotDbContext Context;
        public IMapper Mapper;

        public Type_Of_RequestsQueryTestFixture()
        {
            Context = Type_Of_RequestsContextFactory.Create();
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
            Type_Of_RequestsContextFactory.Destroy(Context);
        }
    }

    [CollectionDefinition("Type_Of_RequestsQueryCollection")]
    public class QueryCollection : ICollectionFixture<Type_Of_RequestsQueryTestFixture> { }
}
