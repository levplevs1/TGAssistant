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

namespace TelegramBot.Application.src.Entities.Type_Of_Requests.Commands.UpdateType_Of_Requests
{
    public class UpdateType_Of_RequestsCommandHandler
        : IRequestHandler<UpdateType_Of_RequestsCommand>
    {
        private readonly ITelegramBotDbContext _dbContext;

        public UpdateType_Of_RequestsCommandHandler(ITelegramBotDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task Handle(UpdateType_Of_RequestsCommand request, CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Type_Of_Requests.FirstOrDefaultAsync(note =>
                note.id_type_of_requests == request.id_type_of_requests, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Type_Of_Requests), request.id_type_of_requests);
            }

            entity.id_housing_and_communal_services = request.id_housing_and_communal_services;
            entity.id_healthcare = request.id_healthcare;
            entity.id_transport = request.id_transport;
            entity.id_education = request.id_education;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return;
        }
    }
}
