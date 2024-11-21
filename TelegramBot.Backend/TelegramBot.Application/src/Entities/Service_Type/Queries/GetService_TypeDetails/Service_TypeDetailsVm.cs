using AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Common.Mapping;
using TelegramBot.Application.src.Entities.Users.Queries.GetUsersDetails;

namespace TelegramBot.Application.src.Entities.Service_Type.Queries.GetService_TypeDetails
{
    public class Service_TypeDetailsVm : IMapWith<Domain.src.Entities.Service_Type>
    {
        public int id_service_type { get; set; }
        public string service_type_name { get; set; }
        public int id_housing_and_communal_services { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.src.Entities.Service_Type, Service_TypeDetailsVm>()
                .ForMember(entityVm => entityVm.id_service_type,
                opt => opt.MapFrom(entity => entity.id_service_type))
                .ForMember(entityVm => entityVm.service_type_name,
                opt => opt.MapFrom(entity => entity.service_type_name))
                .ForMember(entityVm => entityVm.id_housing_and_communal_services,
                opt => opt.MapFrom(entity => entity.id_housing_and_communal_services));
        }
    }
}
