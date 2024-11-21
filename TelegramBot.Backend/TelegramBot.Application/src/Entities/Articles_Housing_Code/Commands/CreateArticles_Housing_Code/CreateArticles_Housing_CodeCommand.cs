using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Articles_Housing_Code.Commands.CreateArticles_Housing_Code
{
    public class CreateArticles_Housing_CodeCommand : IRequest<int>
    {
        public string articles_housing_code_name { get; set; }
        public string articles_housing_code_content { get; set; }
        public int id_housing_and_communal_services { get; set; }
    }
}
