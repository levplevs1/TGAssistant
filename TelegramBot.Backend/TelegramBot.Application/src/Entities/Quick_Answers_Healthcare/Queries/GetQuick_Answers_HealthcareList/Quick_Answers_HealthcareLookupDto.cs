using AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Common.Mapping;
using TelegramBot.Application.src.Entities.Users.Queries.GetUsersList;

namespace TelegramBot.Application.src.Entities.Quick_Answers_Healthcare.Queries.GetQuick_Answers_HealthcareList
{
    public class Quick_Answers_HealthcareLookupDto : IMapWith<Domain.src.Entities.Quick_Answers_Healthcare>
    {
        public int id_quick_answer_healthcare { get; set; }
        public string quick_answer_healthcare_name { get; set; }
        public int id_healthcare { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.src.Entities.Quick_Answers_Healthcare, Quick_Answers_HealthcareLookupDto>()
                .ForMember(entityVm => entityVm.id_quick_answer_healthcare,
                opt => opt.MapFrom(entity => entity.id_quick_answer_healthcare))
                .ForMember(entityVm => entityVm.quick_answer_healthcare_name,
                opt => opt.MapFrom(entity => entity.quick_answer_healthcare_name))
                .ForMember(entityVm => entityVm.id_healthcare,
                opt => opt.MapFrom(entity => entity.id_healthcare));
        }
    }
}
