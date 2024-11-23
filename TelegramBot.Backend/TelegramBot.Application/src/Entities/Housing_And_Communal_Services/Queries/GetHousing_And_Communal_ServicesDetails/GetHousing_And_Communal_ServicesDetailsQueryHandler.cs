using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Common.Exceptions;
using TelegramBot.Application.src.Entities.Users.Queries.GetUsersDetails;
using TelegramBot.Application.src.Interfaces;

namespace TelegramBot.Application.src.Entities.Housing_And_Communal_Services.Queries.GetHousing_And_Communal_ServicesDetails
{
    public class GetHousing_And_Communal_ServicesDetailsQueryHandler
        : IRequestHandler<GetHousing_And_Communal_ServicesDetailsQuery, Housing_And_Communal_ServicesDetailsVm>
    {
        private readonly ITelegramBotDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetHousing_And_Communal_ServicesDetailsQueryHandler(ITelegramBotDbContext dbContext,
            IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<Housing_And_Communal_ServicesDetailsVm> Handle(GetHousing_And_Communal_ServicesDetailsQuery request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Housing_And_Communal_Services
                .FirstOrDefaultAsync(note =>
                note.id_housing_and_communal_services == request.id_housing_and_communal_services, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Domain.src.Entities.Housing_And_Communal_Services), request.id_housing_and_communal_services);
            }

            return _mapper.Map<Housing_And_Communal_ServicesDetailsVm>(entity);
        }
    }
}
