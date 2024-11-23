using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Common.Mapping;
using TelegramBot.Application.src.Entities.Users.Queries.GetUsersDetails;

namespace TelegramBot.Application.src.Entities.Housing_And_Communal_Services.Queries.GetHousing_And_Communal_ServicesDetails
{
    public class Housing_And_Communal_ServicesDetailsVm : IMapWith<Domain.src.Entities.Housing_And_Communal_Services>
    {
        public int id_housing_and_communal_services { get; set; }
        public string text_of_request { get; set; }
        public DateTime created_at { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.src.Entities.Housing_And_Communal_Services, Housing_And_Communal_ServicesDetailsVm>()
                .ForMember(entityVm => entityVm.id_housing_and_communal_services,
                opt => opt.MapFrom(entity => entity.id_housing_and_communal_services))
                .ForMember(entityVm => entityVm.text_of_request,
                opt => opt.MapFrom(entity => entity.text_of_request))
                .ForMember(entityVm => entityVm.created_at,
                opt => opt.MapFrom(entity => entity.created_at));
        }
    }
}
