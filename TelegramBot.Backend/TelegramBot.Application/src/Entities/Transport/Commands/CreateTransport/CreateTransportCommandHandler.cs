using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Entities.Users.Commands.CreateUsers;
using TelegramBot.Application.src.Interfaces;

namespace TelegramBot.Application.src.Entities.Transport.Commands.CreateTransport
{
    public class CreateTransportCommandHandler
        : IRequestHandler<CreateTransportCommand, int>
    {
        private readonly ITelegramBotDbContext _dbContext;

        public CreateTransportCommandHandler(ITelegramBotDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<int> Handle(CreateTransportCommand request, CancellationToken cancellationToken)
        {
            var transport = new Domain.src.Entities.Transport
            {
                text_of_request = request.text_of_request,
                created_at = DateTime.Now
            };

            await _dbContext.Transport.AddAsync(transport, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return transport.id_transport;
        }
    }
}
