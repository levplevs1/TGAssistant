﻿using AutoMapper;
using TelegramBot.Application.src.Common.Mapping;
using TelegramBot.Application.src.Entities.Payments_Method.Commands.CreatePayments_Method;
using TelegramBot.Application.src.Entities.Payments_Method.Queries.GetPayments_MethodDetails;
using TelegramBot.Application.src.Entities.Users.Queries.GetUsersDetails;

namespace TelegramBot.WebApi.src.EntitiesDto.Payments_Method
{
    public class CreatePayments_MethodDto : IMapWith<CreatePayments_MethodCommand>
    {
        public string payments_method_name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreatePayments_MethodDto, CreatePayments_MethodCommand>()
                .ForMember(entityDto => entityDto.payments_method_name,
                opt => opt.MapFrom(entity => entity.payments_method_name));
        }
    }
}
