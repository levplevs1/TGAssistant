using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Common.Exceptions;
using TelegramBot.Application.src.Entities.Users.Commands.UpdateUsers;
using TelegramBot.Application.src.Interfaces;

namespace TelegramBot.Application.src.Entities.Quick_Answers_Transport.Commands.UpdateQuick_Answers_Transport
{
    public class UpdateQuick_Answers_TransportCommandHandler
        : IRequestHandler<UpdateQuick_Answers_TransportCommand>
    {
        private readonly ITelegramBotDbContext _dbContext;

        public UpdateQuick_Answers_TransportCommandHandler(ITelegramBotDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task Handle(UpdateQuick_Answers_TransportCommand request, CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Quick_Answers_Transport.FirstOrDefaultAsync(note =>
                note.id_quick_answer_transport == request.id_quick_answer_transport, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Quick_Answers_Transport), request.id_quick_answer_transport);
            }

            entity.quick_answer_transport_name = request.quick_answer_transport_name;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return;
        }
    }
}
