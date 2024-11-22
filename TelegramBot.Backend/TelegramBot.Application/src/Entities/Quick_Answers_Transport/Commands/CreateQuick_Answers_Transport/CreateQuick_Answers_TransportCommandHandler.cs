using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Entities.Users.Commands.CreateUsers;
using TelegramBot.Application.src.Interfaces;

namespace TelegramBot.Application.src.Entities.Quick_Answers_Transport.Commands.CreateQuick_Answers_Transport
{
    public class CreateQuick_Answers_TransportCommandHandler
        : IRequestHandler<CreateQuick_Answers_TransportCommand, int>
    {
        private readonly ITelegramBotDbContext _dbContext;

        public CreateQuick_Answers_TransportCommandHandler(ITelegramBotDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<int> Handle(CreateQuick_Answers_TransportCommand request, CancellationToken cancellationToken)
        {
            var quick_answers_transport = new Domain.src.Entities.Quick_Answers_Transport
            {
                quick_answer_transport_name = request.quick_answer_transport_name,
                id_transport = request.id_transport
            };

            await _dbContext.Quick_Answers_Transport.AddAsync(quick_answers_transport, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return quick_answers_transport.id_quick_answer_transport;
        }
    }
}
