using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Application.src.Entities.Articles_Housing_Code.Queries.GetArticles_Housing_CodeDetails
{
    public class GetArticles_Housing_CodeDetailsQuery : IRequest<Articles_Housing_CodeDetailsVm>
    {
        public int id_articles_housing_code { get; set; }
    }
}
