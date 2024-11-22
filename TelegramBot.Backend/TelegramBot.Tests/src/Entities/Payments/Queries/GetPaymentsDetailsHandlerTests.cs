using AutoMapper;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Entities.Payments.Queries.GetPaymentsDetails;
using TelegramBot.Application.src.Entities.Users.Queries.GetUsersDetails;
using TelegramBot.Persistence.src.Data;
using TelegramBot.Tests.src.Entities.Payments.Common;
using TelegramBot.Tests.src.Entities.Users.Common;

namespace TelegramBot.Tests.src.Entities.Payments.Queries
{
    [Collection("PaymentsQueryCollection")]
    public class GetPaymentsDetailsHandlerTests
    {
        private readonly TelegramBotDbContext Context;
        private readonly IMapper Mapper;
        public GetPaymentsDetailsHandlerTests(PaymentsQueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }
        [Fact]
        public async Task GetPaymentsDetailsQueryHandler_Success()
        {
            var handler = new GetPaymentsDetailsQueryHandler(Context, Mapper);

            var result = await handler.Handle(
                new GetPaymentsDetailsQuery
                {
                    id_payments = 1
                },
                CancellationToken.None);

            result.ShouldBeOfType<PaymentsDetailsVm>();
            result.amount.ShouldBe(1);
        }
    }
}
