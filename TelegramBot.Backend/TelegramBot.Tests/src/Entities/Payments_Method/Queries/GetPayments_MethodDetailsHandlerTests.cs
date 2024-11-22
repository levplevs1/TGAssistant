using AutoMapper;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Entities.Payments_Method.Queries.GetPayments_MethodDetails;
using TelegramBot.Application.src.Entities.Users.Queries.GetUsersDetails;
using TelegramBot.Persistence.src.Data;
using TelegramBot.Tests.src.Entities.Payments_Method.Common;
using TelegramBot.Tests.src.Entities.Users.Common;

namespace TelegramBot.Tests.src.Entities.Payments_Method.Queries
{
    [Collection("Payments_MethodQueryCollection")]
    public class GetPayments_MethodDetailsHandlerTests
    {
        private readonly TelegramBotDbContext Context;
        private readonly IMapper Mapper;
        public GetPayments_MethodDetailsHandlerTests(Payments_MethodQueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }
        [Fact]
        public async Task GetPayments_MethodDetailsQueryHandler_Success()
        {
            var handler = new GetPayments_MethodDetailsQueryHandler(Context, Mapper);

            var result = await handler.Handle(
                new GetPayments_MethodDetailsQuery
                {
                    id_payments_method = 1
                },
                CancellationToken.None);

            result.ShouldBeOfType<Payments_MethodDetailsVm>();
            result.payments_method_name.ShouldBe("Alto");
        }
    }
}
