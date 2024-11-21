using AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Common.Mapping;
using TelegramBot.Application.src.Entities.Users.Queries.GetUsersDetails;

namespace TelegramBot.Application.src.Entities.Type_Of_Requests.Queries.GetType_Of_RequestsDetails
{
    public class Type_Of_RequestsDetailsVm : IMapWith<Domain.src.Entities.Type_Of_Requests>
    {
        public int id_type_of_requests { get; set; }
        public int? id_housing_and_communal_services { get; set; }
        public int? id_healthcare { get; set; }
        public int? id_transport { get; set; }
        public int? id_education { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.src.Entities.Type_Of_Requests, Type_Of_RequestsDetailsVm>()
                .ForMember(entityVm => entityVm.id_type_of_requests,
                opt => opt.MapFrom(entity => entity.id_type_of_requests))
                .ForMember(entityVm => entityVm.id_housing_and_communal_services,
                opt => opt.MapFrom(entity => entity.id_housing_and_communal_services))
                .ForMember(entityVm => entityVm.id_healthcare,
                opt => opt.MapFrom(entity => entity.id_healthcare))
                .ForMember(entityVm => entityVm.id_transport,
                opt => opt.MapFrom(entity => entity.id_transport))
                .ForMember(entityVm => entityVm.id_education,
                opt => opt.MapFrom(entity => entity.id_education));
        }
    }
}
