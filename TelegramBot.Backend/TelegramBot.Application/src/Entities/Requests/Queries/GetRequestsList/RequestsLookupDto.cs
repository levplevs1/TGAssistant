using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Application.src.Common.Mapping;
using TelegramBot.Application.src.Entities.Requests.Queries.GetRequestsDetails;

namespace TelegramBot.Application.src.Entities.Requests.Queries.GetRequestsList
{
    public class RequestsLookupDto : IMapWith<Domain.src.Entities.Requests>
    {
        public int id_requests { get; set; }
        public string request_text { get; set; }
        public string response { get; set; }
        public DateTime created_at { get; set; }
        public int id_type_of_requests { get; set; }
        public int id_users { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.src.Entities.Requests, RequestsLookupDto>()
                .ForMember(entityVm => entityVm.id_requests,
                opt => opt.MapFrom(entity => entity.id_requests))
                .ForMember(entityVm => entityVm.request_text,
                opt => opt.MapFrom(entity => entity.request_text))
                .ForMember(entityVm => entityVm.response,
                opt => opt.MapFrom(entity => entity.response))
                .ForMember(entityVm => entityVm.created_at,
                opt => opt.MapFrom(entity => entity.created_at))
                .ForMember(entityVm => entityVm.id_type_of_requests,
                opt => opt.MapFrom(entity => entity.id_type_of_requests))
                .ForMember(entityVm => entityVm.id_users,
                opt => opt.MapFrom(entity => entity.id_users));
        }
    }
}
