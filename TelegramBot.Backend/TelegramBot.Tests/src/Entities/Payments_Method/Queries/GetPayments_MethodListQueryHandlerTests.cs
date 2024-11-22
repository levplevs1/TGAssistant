using AutoMapper;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Entities.Payments_Method.Queries.GetPayments_MethodList;
using TelegramBot.Application.src.Entities.Users.Queries.GetUsersList;
using TelegramBot.Persistence.src.Data;
using TelegramBot.Tests.src.Entities.Payments_Method.Common;
using TelegramBot.Tests.src.Entities.Users.Common;

namespace TelegramBot.Tests.src.Entities.Payments_Method.Queries
{
    [Collection("Payments_MethodQueryCollection")]
    public class GetPayments_MethodListQueryHandlerTests
    {
        private readonly TelegramBotDbContext Context;
        private readonly IMapper Mapper;

        public GetPayments_MethodListQueryHandlerTests(Payments_MethodQueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetPayments_MethodListQueryHandler_Success()
        {
            var handler = new GetPayments_MethodListQueryHandler(Context, Mapper);

            var result = await handler.Handle(
                new GetPayments_MethodListQuery(),
                CancellationToken.None);

            result.ShouldBeOfType<Payments_MethodListVm>();
            result.Payments_Method.Count.ShouldBe(4);
        }
    }
}
