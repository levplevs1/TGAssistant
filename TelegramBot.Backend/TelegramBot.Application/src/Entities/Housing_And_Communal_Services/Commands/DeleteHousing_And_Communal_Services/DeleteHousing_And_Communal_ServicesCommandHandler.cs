using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Common.Exceptions;
using TelegramBot.Application.src.Entities.Users.Commands.DeleteUsers;
using TelegramBot.Application.src.Interfaces;

namespace TelegramBot.Application.src.Entities.Housing_And_Communal_Services.Commands.DeleteHousing_And_Communal_Services
{
    public class DeleteHousing_And_Communal_ServicesCommandHandler
        : IRequestHandler<DeleteHousing_And_Communal_ServicesCommand>
    {
        private readonly ITelegramBotDbContext _dbContext;

        public DeleteHousing_And_Communal_ServicesCommandHandler(ITelegramBotDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task Handle(DeleteHousing_And_Communal_ServicesCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Housing_And_Communal_Services
                .FindAsync(new object[] { request.id_housing_and_communal_services }, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Housing_And_Communal_Services), request.id_housing_and_communal_services);
            }

            _dbContext.Housing_And_Communal_Services.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return;
        }
    }
}
