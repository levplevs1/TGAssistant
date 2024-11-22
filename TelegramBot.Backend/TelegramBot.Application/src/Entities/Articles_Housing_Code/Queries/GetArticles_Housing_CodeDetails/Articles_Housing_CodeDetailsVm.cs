using AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Common.Mapping;
using TelegramBot.Application.src.Entities.Users.Queries.GetUsersDetails;

namespace TelegramBot.Application.src.Entities.Articles_Housing_Code.Queries.GetArticles_Housing_CodeDetails
{
    public class Articles_Housing_CodeDetailsVm : IMapWith<Domain.src.Entities.Articles_Housing_Code>
    {
        public int id_articles_housing_code { get; set; }
        public string articles_housing_code_name { get; set; }
        public string articles_housing_code_content { get; set; }
        public int id_housing_and_communal_services { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.src.Entities.Articles_Housing_Code, Articles_Housing_CodeDetailsVm>()
                .ForMember(entityVm => entityVm.id_articles_housing_code,
                opt => opt.MapFrom(entity => entity.id_articles_housing_code))
                .ForMember(entityVm => entityVm.articles_housing_code_name,
                opt => opt.MapFrom(entity => entity.articles_housing_code_name))
                .ForMember(entityVm => entityVm.articles_housing_code_content,
                opt => opt.MapFrom(entity => entity.articles_housing_code_content))
                .ForMember(entityVm => entityVm.id_housing_and_communal_services,
                opt => opt.MapFrom(entity => entity.id_housing_and_communal_services));
        }
    }
}
