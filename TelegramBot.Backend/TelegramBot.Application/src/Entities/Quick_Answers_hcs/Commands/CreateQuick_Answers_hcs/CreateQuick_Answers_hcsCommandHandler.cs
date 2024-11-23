using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Entities.Users.Commands.CreateUsers;
using TelegramBot.Application.src.Interfaces;

namespace TelegramBot.Application.src.Entities.Quick_Answers_hcs.Commands.CreateQuick_Answers_hcs
{
    public class CreateQuick_Answers_hcsCommandHandler
        : IRequestHandler<CreateQuick_Answers_hcsCommand, int>
    {
        private readonly ITelegramBotDbContext _dbContext;

        public CreateQuick_Answers_hcsCommandHandler(ITelegramBotDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<int> Handle(CreateQuick_Answers_hcsCommand request, CancellationToken cancellationToken)
        {
            var quick_answers_hcs = new Domain.src.Entities.Quick_Answers_hcs
            {
                quick_answers_hcs_name = request.quick_answers_hcs_name,
                quick_answers_hcs_content = request.quick_answers_hcs_content,
                id_housing_and_communal_services = request.id_housing_and_communal_services
            };

            await _dbContext.Quick_Answers_hcs.AddAsync(quick_answers_hcs, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return quick_answers_hcs.id_quick_answers_hcs;
        }
    }
}
