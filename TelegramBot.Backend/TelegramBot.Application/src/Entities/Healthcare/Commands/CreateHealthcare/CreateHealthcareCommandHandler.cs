using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Entities.Users.Commands.CreateUsers;
using TelegramBot.Application.src.Interfaces;

namespace TelegramBot.Application.src.Entities.Healthcare.Commands.CreateHealthcare
{
    public class CreateHealthcareCommandHandler
        : IRequestHandler<CreateHealthcareCommand, int>
    {
        private readonly ITelegramBotDbContext _dbContext;

        public CreateHealthcareCommandHandler(ITelegramBotDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<int> Handle(CreateHealthcareCommand request, CancellationToken cancellationToken)
        {
            var healthcare = new Domain.src.Entities.Healthcare
            {
                text_of_request = request.text_of_request,
                created_at = DateTime.Now
            };

            await _dbContext.Healthcare.AddAsync(healthcare, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return healthcare.id_healthcare;
        }
    }
}
