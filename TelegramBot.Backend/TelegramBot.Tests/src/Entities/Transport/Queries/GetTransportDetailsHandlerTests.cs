﻿using AutoMapper;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Entities.Transport.Queries.GetTransportDetails;
using TelegramBot.Application.src.Entities.Users.Queries.GetUsersDetails;
using TelegramBot.Persistence.src.Data;
using TelegramBot.Tests.src.Entities.Transport.Common;
using TelegramBot.Tests.src.Entities.Users.Common;

namespace TelegramBot.Tests.src.Entities.Transport.Queries
{
    [Collection("TransportQueryCollection")]
    public class GetTransportDetailsHandlerTests
    {
        private readonly TelegramBotDbContext Context;
        private readonly IMapper Mapper;
        public GetTransportDetailsHandlerTests(TransportQueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }
        [Fact]
        public async Task GetTransportDetailsQueryHandler_Success()
        {
            var handler = new GetTransportDetailsQueryHandler(Context, Mapper);

            var result = await handler.Handle(
                new GetTransportDetailsQuery
                {
                    id_transport = 1
                },
                CancellationToken.None);

            result.ShouldBeOfType<TransportDetailsVm>();
            result.text_of_request.ShouldBe("Alto");
        }
    }
}