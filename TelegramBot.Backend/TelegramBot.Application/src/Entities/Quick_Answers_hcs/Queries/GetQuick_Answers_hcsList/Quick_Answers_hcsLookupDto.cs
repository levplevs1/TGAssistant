using AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Common.Mapping;
using TelegramBot.Application.src.Entities.Users.Queries.GetUsersList;

namespace TelegramBot.Application.src.Entities.Quick_Answers_hcs.Queries.GetQuick_Answers_hcsList
{
    public class Quick_Answers_hcsLookupDto : IMapWith<Domain.src.Entities.Quick_Answers_hcs>
    {
        public int id_quick_answers_hcs { get; set; }
        public string quick_answers_hcs_name { get; set; }
        public string quick_answers_hcs_content { get; set; }
        public int id_housing_and_communal_services { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.src.Entities.Quick_Answers_hcs, Quick_Answers_hcsLookupDto>()
                .ForMember(entityVm => entityVm.id_quick_answers_hcs,
                opt => opt.MapFrom(entity => entity.id_quick_answers_hcs))
                .ForMember(entityVm => entityVm.quick_answers_hcs_name,
                opt => opt.MapFrom(entity => entity.quick_answers_hcs_name))
                .ForMember(entityVm => entityVm.quick_answers_hcs_content,
                opt => opt.MapFrom(entity => entity.quick_answers_hcs_content))
                .ForMember(entityVm => entityVm.id_housing_and_communal_services,
                opt => opt.MapFrom(entity => entity.id_housing_and_communal_services));
        }
    }
}
