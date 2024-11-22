using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Entities.Users.Queries.GetUsersList;
using TelegramBot.Application.src.Interfaces;

namespace TelegramBot.Application.src.Entities.Housing_And_Communal_Services.Queries.GetHousing_And_Communal_ServicesList
{
    public class GetHousing_And_Communal_ServicesListQueryHandler
        : IRequestHandler<GetHousing_And_Communal_ServicesListQuery, Housing_And_Communal_ServicesListVm>
    {
        private readonly ITelegramBotDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetHousing_And_Communal_ServicesListQueryHandler(ITelegramBotDbContext dbContext,
            IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<Housing_And_Communal_ServicesListVm> Handle(GetHousing_And_Communal_ServicesListQuery request,
            CancellationToken cancellationToken)
        {
            var entityQuery = await _dbContext.Housing_And_Communal_Services
                .ProjectTo<Housing_And_Communal_ServicesLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new Housing_And_Communal_ServicesListVm { Housing_And_Communal_Services = entityQuery };
        }
    }
}
