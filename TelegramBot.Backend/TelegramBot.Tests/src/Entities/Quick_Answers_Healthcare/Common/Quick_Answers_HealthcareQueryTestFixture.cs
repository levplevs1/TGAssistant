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

namespace TelegramBot.Tests.src.Entities.Quick_Answers_Healthcare.Common
{
    public class Quick_Answers_HealthcareQueryTestFixture : IDisposable
    {
        public TelegramBotDbContext Context;
        public IMapper Mapper;

        public Quick_Answers_HealthcareQueryTestFixture()
        {
            Context = Quick_Answers_HealthcareContextFactory.Create();
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
            Quick_Answers_HealthcareContextFactory.Destroy(Context);
        }
    }

    [CollectionDefinition("Quick_Answers_HealthcareQueryCollection")]
    public class QueryCollection : ICollectionFixture<Quick_Answers_HealthcareQueryTestFixture> { }
}
