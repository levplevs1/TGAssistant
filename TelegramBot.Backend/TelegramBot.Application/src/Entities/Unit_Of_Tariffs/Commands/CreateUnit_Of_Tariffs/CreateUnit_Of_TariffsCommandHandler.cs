using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Entities.Users.Commands.CreateUsers;
using TelegramBot.Application.src.Interfaces;

namespace TelegramBot.Application.src.Entities.Unit_Of_Tariffs.Commands.CreateUnit_Of_Tariffs
{
    public class CreateUnit_Of_TariffsCommandHandler
        : IRequestHandler<CreateUnit_Of_TariffsCommand, int>
    {
        private readonly ITelegramBotDbContext _dbContext;

        public CreateUnit_Of_TariffsCommandHandler(ITelegramBotDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<int> Handle(CreateUnit_Of_TariffsCommand request, CancellationToken cancellationToken)
        {
            var unit_of_tariffs = new Domain.src.Entities.Unit_Of_Tariffs
            {
                unit_of_tariffs_name = request.unit_of_tariffs_name
            };

            await _dbContext.Unit_Of_Tariffs.AddAsync(unit_of_tariffs, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return unit_of_tariffs.id_unit_of_tariffs;
        }
    }
}
