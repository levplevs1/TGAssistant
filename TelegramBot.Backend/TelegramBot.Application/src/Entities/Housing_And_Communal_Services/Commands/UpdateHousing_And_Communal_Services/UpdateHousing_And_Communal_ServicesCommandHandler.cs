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

namespace TelegramBot.Application.src.Entities.Housing_And_Communal_Services.Commands.UpdateHousing_And_Communal_Services
{
    public class UpdateHousing_And_Communal_ServicesCommandHandler 
        : IRequestHandler<UpdateHousing_And_Communal_ServicesCommand>
    {
        private readonly ITelegramBotDbContext _dbContext;

        public UpdateHousing_And_Communal_ServicesCommandHandler(ITelegramBotDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task Handle(UpdateHousing_And_Communal_ServicesCommand request, CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Housing_And_Communal_Services.FirstOrDefaultAsync(note =>
                note.id_housing_and_communal_services == request.id_housing_and_communal_services, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Housing_And_Communal_Services), request.id_housing_and_communal_services);
            }

            entity.text_of_request = request.text_of_request;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return;
        }
    }
}
