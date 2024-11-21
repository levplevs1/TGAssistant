using AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Common.Mapping;
using TelegramBot.Application.src.Entities.Users.Queries.GetUsersList;

namespace TelegramBot.Application.src.Entities.Quick_Answers_Transport.Queries.GetQuick_Answers_TransportList
{
    public class Quick_Answers_TransportLookupDto : IMapWith<Domain.src.Entities.Quick_Answers_Transport>
    {
        public int id_quick_answer_transport { get; set; }
        public string quick_answer_transport_name { get; set; }
        public int id_transport { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.src.Entities.Quick_Answers_Transport, Quick_Answers_TransportLookupDto>()
                .ForMember(entityVm => entityVm.id_quick_answer_transport,
                opt => opt.MapFrom(entity => entity.id_quick_answer_transport))
                .ForMember(entityVm => entityVm.quick_answer_transport_name,
                opt => opt.MapFrom(entity => entity.quick_answer_transport_name))
                .ForMember(entityVm => entityVm.id_transport,
                opt => opt.MapFrom(entity => entity.id_transport));
        }
    }
}
