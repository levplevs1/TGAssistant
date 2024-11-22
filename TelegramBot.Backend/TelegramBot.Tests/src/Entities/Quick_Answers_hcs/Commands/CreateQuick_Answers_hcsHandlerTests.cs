using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Entities.Quick_Answers_hcs.Commands.CreateQuick_Answers_hcs;
using TelegramBot.Application.src.Entities.Users.Commands.CreateUsers;
using TelegramBot.Tests.src.Entities.Quick_Answers_hcs.Common;

namespace TelegramBot.Tests.src.Entities.Quick_Answers_hcs.Commands
{
    public class CreateQuick_Answers_hcsHandlerTests : Quick_Answers_hcsTestCommandBase
    {
        [Fact]
        public async Task CreateQuick_Answers_hcsCommandHandler_Success()
        {
            var handler = new CreateQuick_Answers_hcsCommandHandler(Context);
            var id_housing_and_communal_services = 6;
            var quick_answers_hcs_name = "Malenia";
            var quick_answers_hcs_content = "Maliket";

            var id_quick_answers_hcs = await handler.Handle(
                new CreateQuick_Answers_hcsCommand
                {
                    quick_answers_hcs_name = quick_answers_hcs_name,
                    quick_answers_hcs_content = quick_answers_hcs_content,
                    id_housing_and_communal_services = id_housing_and_communal_services
                },
                CancellationToken.None);

            Assert.NotNull(
               await Context.Quick_Answers_hcs.SingleOrDefaultAsync(entity =>
               entity.id_quick_answers_hcs == id_quick_answers_hcs &&
               entity.quick_answers_hcs_name == quick_answers_hcs_name &&
               entity.quick_answers_hcs_content == quick_answers_hcs_content &&
               entity.id_housing_and_communal_services == id_housing_and_communal_services));
        }
    }
}
