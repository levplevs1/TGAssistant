﻿using AutoMapper;
using System.ComponentModel.DataAnnotations.Schema;
using TelegramBot.Application.src.Common.Mapping;
using TelegramBot.Application.src.Entities.Articles_Housing_Code.Commands.CreateArticles_Housing_Code;
using TelegramBot.Application.src.Entities.Articles_Housing_Code.Queries.GetArticles_Housing_CodeDetails;
using TelegramBot.Application.src.Entities.Users.Queries.GetUsersDetails;

namespace TelegramBot.WebApi.src.EntitiesDto.Articles_Housing_Code
{
    public class CreateArticles_Housing_CodeDto : IMapWith<CreateArticles_Housing_CodeCommand>
    {
        public string articles_housing_code_name { get; set; }
        public string articles_housing_code_content { get; set; }
        public int id_housing_and_communal_services { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateArticles_Housing_CodeDto, CreateArticles_Housing_CodeCommand>()
                .ForMember(entityDto => entityDto.articles_housing_code_name,
                opt => opt.MapFrom(entity => entity.articles_housing_code_name))
                .ForMember(entityDto => entityDto.articles_housing_code_content,
                opt => opt.MapFrom(entity => entity.articles_housing_code_content))
                .ForMember(entityDto => entityDto.id_housing_and_communal_services,
                opt => opt.MapFrom(entity => entity.id_housing_and_communal_services));
        }
    }
}
