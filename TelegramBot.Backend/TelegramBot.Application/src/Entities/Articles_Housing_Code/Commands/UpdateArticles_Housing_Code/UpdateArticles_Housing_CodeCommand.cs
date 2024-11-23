using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Articles_Housing_Code.Commands.UpdateArticles_Housing_Code
{
    public class UpdateArticles_Housing_CodeCommand : IRequest
    {
        public int id_articles_housing_code { get; set; }
        public string articles_housing_code_name { get; set; }
        public string articles_housing_code_content { get; set; }
    }
}
