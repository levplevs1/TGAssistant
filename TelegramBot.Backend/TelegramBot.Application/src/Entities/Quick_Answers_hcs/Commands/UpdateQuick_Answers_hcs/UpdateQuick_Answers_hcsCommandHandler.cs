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

namespace TelegramBot.Application.src.Entities.Quick_Answers_hcs.Commands.UpdateQuick_Answers_hcs
{
    public class UpdateQuick_Answers_hcsCommandHandler
        : IRequestHandler<UpdateQuick_Answers_hcsCommand>
    {
        private readonly ITelegramBotDbContext _dbContext;

        public UpdateQuick_Answers_hcsCommandHandler(ITelegramBotDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task Handle(UpdateQuick_Answers_hcsCommand request, CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Quick_Answers_hcs.FirstOrDefaultAsync(note =>
                note.id_quick_answers_hcs == request.id_quick_answers_hcs, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Quick_Answers_hcs), request.id_quick_answers_hcs);
            }

            entity.quick_answers_hcs_name = request.quick_answers_hcs_name;
            entity.quick_answers_hcs_content = request.quick_answers_hcs_content;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return;
        }
    }
}
