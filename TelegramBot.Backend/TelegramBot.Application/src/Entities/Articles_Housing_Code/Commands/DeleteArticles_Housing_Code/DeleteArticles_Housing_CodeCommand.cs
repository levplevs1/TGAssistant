using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Articles_Housing_Code.Commands.DeleteArticles_Housing_Code
{
    public class DeleteArticles_Housing_CodeCommand : IRequest
    {
        public int id_articles_housing_code { get; set; }
    }
}
