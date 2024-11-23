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

namespace TelegramBot.Tests.src.Entities.Payments.Common
{
    public class PaymentsQueryTestFixture
    {
        public TelegramBotDbContext Context;
        public IMapper Mapper;

        public PaymentsQueryTestFixture()
        {
            Context = PaymentsContextFactory.Create();
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
            PaymentsContextFactory.Destroy(Context);
        }
    }

    [CollectionDefinition("PaymentsQueryCollection")]
    public class QueryCollection : ICollectionFixture<PaymentsQueryTestFixture> { }
}
