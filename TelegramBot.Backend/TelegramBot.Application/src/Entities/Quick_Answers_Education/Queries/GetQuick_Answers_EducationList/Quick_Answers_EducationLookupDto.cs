using AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Common.Mapping;
using TelegramBot.Application.src.Entities.Users.Queries.GetUsersList;

namespace TelegramBot.Application.src.Entities.Quick_Answers_Education.Queries.GetQuick_Answers_EducationList
{
    public class Quick_Answers_EducationLookupDto : IMapWith<Domain.src.Entities.Quick_Answers_Education>
    {
        public int id_quick_answer_education { get; set; }
        public string quick_answer_education_name { get; set; }
        public int id_education { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.src.Entities.Quick_Answers_Education, Quick_Answers_EducationLookupDto>()
                .ForMember(entityVm => entityVm.id_quick_answer_education,
                opt => opt.MapFrom(entity => entity.id_quick_answer_education))
                .ForMember(entityVm => entityVm.quick_answer_education_name,
                opt => opt.MapFrom(entity => entity.quick_answer_education_name))
                .ForMember(entityVm => entityVm.id_education,
                opt => opt.MapFrom(entity => entity.id_education));
        }
    }
}
