using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Common.Exceptions;
using TelegramBot.Application.src.Entities.Users.Commands.DeleteUsers;
using TelegramBot.Application.src.Interfaces;

namespace TelegramBot.Application.src.Entities.Quick_Answers_Transport.Commands.DeleteQuick_Answers_Transport
{
    public class DeleteQuick_Answers_TransportCommandHandler
        : IRequestHandler<DeleteQuick_Answers_TransportCommand>
    {
        private readonly ITelegramBotDbContext _dbContext;

        public DeleteQuick_Answers_TransportCommandHandler(ITelegramBotDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task Handle(DeleteQuick_Answers_TransportCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Quick_Answers_Transport
                .FindAsync(new object[] { request.id_quick_answer_transport }, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Quick_Answers_Transport), request.id_quick_answer_transport);
            }

            _dbContext.Quick_Answers_Transport.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return;
        }
    }
}
