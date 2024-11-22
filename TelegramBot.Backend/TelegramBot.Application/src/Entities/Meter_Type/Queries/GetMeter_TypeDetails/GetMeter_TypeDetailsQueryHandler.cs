﻿using AutoMapper;
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

namespace TelegramBot.Application.src.Entities.Meter_Type.Queries.GetMeter_TypeDetails
{
    public class GetMeter_TypeDetailsQueryHandler
        : IRequestHandler<GetMeter_TypeDetailsQuery, Meter_TypeDetailsVm>
    {
        private readonly ITelegramBotDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetMeter_TypeDetailsQueryHandler(ITelegramBotDbContext dbContext,
            IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<Meter_TypeDetailsVm> Handle(GetMeter_TypeDetailsQuery request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Meter_Type
                .FirstOrDefaultAsync(note =>
                note.id_meter_type == request.id_meter_type, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Domain.src.Entities.Meter_Type), request.id_meter_type);
            }

            return _mapper.Map<Meter_TypeDetailsVm>(entity);
        }
    }
}
