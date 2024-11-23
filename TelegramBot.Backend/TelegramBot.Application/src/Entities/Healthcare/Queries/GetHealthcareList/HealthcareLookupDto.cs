using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Common.Mapping;
using TelegramBot.Application.src.Entities.Users.Queries.GetUsersList;

namespace TelegramBot.Application.src.Entities.Healthcare.Queries.GetHealthcareList
{
    public class HealthcareLookupDto : IMapWith<Domain.src.Entities.Healthcare>
    {
        public int id_healthcare { get; set; }
        public string text_of_request { get; set; }
        public DateTime created_at { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.src.Entities.Healthcare, HealthcareLookupDto>()
                .ForMember(entityVm => entityVm.id_healthcare,
                opt => opt.MapFrom(entity => entity.id_healthcare))
                .ForMember(entityVm => entityVm.text_of_request,
                opt => opt.MapFrom(entity => entity.text_of_request))
                .ForMember(entityVm => entityVm.created_at,
                opt => opt.MapFrom(entity => entity.created_at));
        }
    }
}
