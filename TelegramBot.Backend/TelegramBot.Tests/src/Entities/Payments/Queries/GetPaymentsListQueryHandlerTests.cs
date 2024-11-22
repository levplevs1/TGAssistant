using AutoMapper;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Entities.Payments.Queries.GetPaymentsList;
using TelegramBot.Application.src.Entities.Users.Queries.GetUsersList;
using TelegramBot.Persistence.src.Data;
using TelegramBot.Tests.src.Entities.Payments.Common;
using TelegramBot.Tests.src.Entities.Users.Common;

namespace TelegramBot.Tests.src.Entities.Payments.Queries
{
    [Collection("PaymentsQueryCollection")]
    public class GetPaymentsListQueryHandlerTests
    {
        private readonly TelegramBotDbContext Context;
        private readonly IMapper Mapper;

        public GetPaymentsListQueryHandlerTests(PaymentsQueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetPaymentsListQueryHandler_Success()
        {
            var handler = new GetPaymentsListQueryHandler(Context, Mapper);

            var result = await handler.Handle(
                new GetPaymentsListQuery(),
                CancellationToken.None);

            result.ShouldBeOfType<PaymentsListVm>();
            result.Payments.Count.ShouldBe(4);
        }
    }
}
