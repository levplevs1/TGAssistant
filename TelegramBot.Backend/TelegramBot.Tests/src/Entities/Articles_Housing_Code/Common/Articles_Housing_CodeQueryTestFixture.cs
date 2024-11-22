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

namespace TelegramBot.Tests.src.Entities.Articles_Housing_Code.Common
{
    public class Articles_Housing_CodeQueryTestFixture : IDisposable
    {
        public TelegramBotDbContext Context;
        public IMapper Mapper;

        public Articles_Housing_CodeQueryTestFixture()
        {
            Context = Articles_Housing_CodeContextFactory.Create();
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
            Articles_Housing_CodeContextFactory.Destroy(Context);
        }
    }

    [CollectionDefinition("Articles_Housing_CodeQueryCollection")]
    public class QueryCollection : ICollectionFixture<Articles_Housing_CodeQueryTestFixture> { }
}
