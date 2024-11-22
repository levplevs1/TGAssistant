using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Common.Mapping;
using TelegramBot.Application.src.Entities.Users.Queries.GetUsersDetails;

namespace TelegramBot.Application.src.Entities.Education.Queries.GetEducationDetails
{
    public class EducationDetailsVm : IMapWith<Domain.src.Entities.Education>
    {
        public int id_education { get; set; }
        public string text_of_request { get; set; }
        public DateTime created_at { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.src.Entities.Education, EducationDetailsVm>()
                .ForMember(entityVm => entityVm.id_education,
                opt => opt.MapFrom(entity => entity.id_education))
                .ForMember(entityVm => entityVm.text_of_request,
                opt => opt.MapFrom(entity => entity.text_of_request))
                .ForMember(entityVm => entityVm.created_at,
                opt => opt.MapFrom(entity => entity.created_at));
        }
    }
}
